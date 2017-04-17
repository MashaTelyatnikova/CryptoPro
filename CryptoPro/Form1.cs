using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace CryptoPro
{
    public partial class Form1 : Form
    {
        private readonly X509Certificate2Collection certificates;
        private X509Certificate2 selectedCertificate = null;
        private RSACryptoServiceProvider cryptoServiceProvider = null;

        public Form1()
        {
            var store = new X509Store();
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            certificates = store.Certificates;

            InitializeComponent();
        }

        private void DownloadCertificate(object sender, System.EventArgs e)
        {
            var scollection =
                X509Certificate2UI.SelectFromCollection(this.certificates,
                    "Выбор секретного ключа по сертификату",
                    "Выберите сертификат, соответствующий Вашему секретному ключу",
                    X509SelectionFlag.SingleSelection);

            if (scollection.Count == 0)
            {
                MessageBox.Show("Вы не выбрали ни одного сертификата.");
                return;
            }

            selectedCertificate = scollection[0];
            cryptoServiceProvider = (RSACryptoServiceProvider) selectedCertificate.PrivateKey;

            if (!selectedCertificate.HasPrivateKey)
            {
                MessageBox.Show("Не удается получить секретный ключ, соответствующий данному сертификату.");
            }

            this.certificateInfo.Text =
                $"Загружен сертификат.\r\nТеперь вы можете подписывать, шифровать и расшифровывать файлы от имени субъекта.\r\n \r\nСубъект: {selectedCertificate.Subject}\r\n\r\nАлгоритм подписи: {selectedCertificate.PublicKey.Oid.FriendlyName}";
            EnableAll();
        }

        private void EnableAll()
        {
            this.exportPublickKeyButton.Enabled = true;
            this.signButton.Enabled = true;
            this.decryptFileButton.Enabled = true;
            this.encryptFileButton.Enabled = true;
        }

        private void Sign(object sender, System.EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Выберите файл для подписи"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Файл для подписи не был выбран");
                return;
            }

            var data = File.ReadAllBytes(openFileDialog.FileName);
            var signedData = cryptoServiceProvider.SignData(data, "SHA1");
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Length > 0)
            {
                using (var ofs = new FileStream(saveFileDialog.FileName,
                    FileMode.Create))
                {
                    var bw = new BinaryWriter(ofs);
                    bw.Write(signedData.Length);
                    bw.Write(signedData);
                    MessageBox.Show("Файл успешно подписан");
                }
            }
            else
            {
                MessageBox.Show("Файл не был подписан");
            }
        }

        private void CheckSiganture(object sender, System.EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Выберите подписанный файл"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Подписанный файл не был выбран");
                return;
            }

            var rawData = File.ReadAllBytes(openFileDialog.FileName);
            var openSignatureDialog = new OpenFileDialog
            {
                Title = "Выберите файл подписи"
            };
            if (openSignatureDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Файл с подписью не был выбран");
                return;
            }
            var openPublicKeyDialog = new OpenFileDialog
            {
                Title = "Выберите файл с открытым ключом подписавшего"
            };
            if (openPublicKeyDialog.ShowDialog() != DialogResult.OK)

            {
                MessageBox.Show("Файл с открытым ключом не был выбран");
                return;
            }

            using (var ifs = new FileStream(openSignatureDialog.FileName,
                FileMode.Open, FileAccess.Read))
            {
                using (var ifsPK = new
                    FileStream(openPublicKeyDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    var formatterPK = new BinaryFormatter();
                    var alg = new RSACryptoServiceProvider();
                    alg.ImportParameters((RSAParameters) formatterPK.Deserialize(ifsPK));
                    var br = new BinaryReader(ifs);
                    var signatureLength = br.ReadInt32();
                    var signature = br.ReadBytes(signatureLength);
                    MessageBox.Show(alg.VerifyData(rawData, "SHA1", signature)
                        ? "Подпись верна"
                        : "Подпись не верна");
                }
            }
        }

        private void ExportPublickKey(object sender, System.EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != DialogResult.OK ||
                saveFileDialog.FileName.Length <= 0)
            {
                MessageBox.Show("Экспортировать открытый ключ не удалось");
            }

            using (var ofs = new FileStream(saveFileDialog.FileName,
                FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ofs, cryptoServiceProvider.ExportParameters(false));
                MessageBox.Show("Открытый ключ успешно экспортирован");
            }
        }

        private void EncryptFile(object sender, System.EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Выберите файл для шифрования"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Файл для шифрования не был выбран");
                return;
            }

            var rsa = new RSACryptoServiceProvider();
            RijndaelManaged RM = new RijndaelManaged();

            //Encrypt the symmetric key and IV.
            var encryptedSymmetricKey = cryptoServiceProvider.Encrypt(RM.Key, false);
            var encryptedSymmetricIV = cryptoServiceProvider.Encrypt(RM.IV, false);

            var encryptor = RM.CreateEncryptor();

            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() != DialogResult.OK ||
                saveFileDialog.FileName.Length <= 0)
                return;

            using (var ofs = new FileStream(saveFileDialog.FileName,
                FileMode.Create))
            {
                var bw = new BinaryWriter(ofs);
                //TODO
            }
        }

        private void DecryptFile(object sender, System.EventArgs e)
        {
        }

        private void DeleteFile(object sender, System.EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Все файлы|*.*",
                Title = "Выберите файл для гарантированного удаления"
            };
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Файл для удаления не был выбран");
                return;
            }

            var result = MessageBox.Show("Файл перезаписан случайными данными.Удалить ? ",
                "Гарантированное удаление файла",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var fi = new FileInfo(dialog.FileName);
                var size = fi.Length;
                using (var ofs = new FileStream(dialog.FileName, FileMode.Truncate))
                {
                    var rng = new RNGCryptoServiceProvider();
                    for (var i = 0; i < size; i += 4096)
                    {
                        var len = size - i < 4096 ? size - i : 4096;
                        var rand = new byte[len];
                        rng.GetBytes(rand);
                        ofs.Write(rand, 0, (int) len);
                        ofs.Write(rand, 0, (int) len);
                    }
                }
                File.Delete(dialog.FileName);
                MessageBox.Show("Файл был успешно удалён");
            }
        }
    }
}