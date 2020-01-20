using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace ThisPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddFolderToThisPC(
                "{497bec52-4c89-4de4-aeb5-334b83bfddec}",
                rbLocalMachine.Checked,
                txtFolderName.Text,
                txtFolderPath.Text,
                txtFolderTooltip.Text,
                txtFolderIconPath.Text))
            {
                MessageBox.Show("Added");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        public bool AddFolderToThisPC(string guid, bool localComputer, string folderName, string folderPath, string tooltip, string iconPath)
        {
            try
            {
                RegistryKey localKey, keyTemp, rootKey;

                var hive = localComputer ? RegistryHive.LocalMachine : RegistryHive.CurrentUser;
                localKey = Environment.Is64BitOperatingSystem
                    ? RegistryKey.OpenBaseKey(hive, RegistryView.Registry64)
                    : RegistryKey.OpenBaseKey(hive, RegistryView.Registry32);


                rootKey = localKey.CreateSubKey(@"SOFTWARE\Classes\CLSID\" + guid);
                rootKey.SetValue("", folderName, RegistryValueKind.String);
                rootKey.SetValue("DescriptionID", unchecked(0x4), RegistryValueKind.DWord);
                rootKey.SetValue("Infotip", tooltip, RegistryValueKind.ExpandString);
                rootKey.SetValue("System.IsPinnedToNameSpaceTree", unchecked(0x1), RegistryValueKind.DWord);

                keyTemp = rootKey.CreateSubKey("DefaultIcon");
                keyTemp.SetValue("", iconPath, RegistryValueKind.String);
                keyTemp.Close();

                keyTemp = rootKey.CreateSubKey("InProcServer32");
                keyTemp.SetValue("", @"%systemroot%\system32\shell32.dll", RegistryValueKind.ExpandString);
                keyTemp.SetValue("ThreadingModel", "Both", RegistryValueKind.String);
                keyTemp.Close();

                keyTemp = rootKey.CreateSubKey("ShellFolder");
                keyTemp.SetValue("Attributes", unchecked((int)0xf080004d), RegistryValueKind.DWord);
                keyTemp.SetValue("FolderValueFlags", unchecked(0x29), RegistryValueKind.DWord);
                keyTemp.SetValue("SortOrderIndex", unchecked(0x0), RegistryValueKind.DWord);
                keyTemp.Close();

                keyTemp = rootKey.CreateSubKey("Instance");
                keyTemp.SetValue("CLSID", "{0E5AAE11-A475-4c5b-AB00-C66DE400274E}", RegistryValueKind.String);
                keyTemp.Close();

                keyTemp = rootKey.CreateSubKey(@"Instance\InitPropertyBag");
                keyTemp.SetValue("Attributes", unchecked(0x11), RegistryValueKind.DWord);
                keyTemp.SetValue("TargetFolderPath", folderPath, RegistryValueKind.String);
                keyTemp.Close();

                keyTemp = localKey.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\" + guid);
                keyTemp.Close();

                rootKey.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveFolderFromThisPC(string guid, bool localComputer)
        {
            try
            {
                var hive = localComputer ? RegistryHive.LocalMachine : RegistryHive.CurrentUser;
                var localKey = Environment.Is64BitOperatingSystem
                    ? RegistryKey.OpenBaseKey(hive, RegistryView.Registry64)
                    : RegistryKey.OpenBaseKey(hive, RegistryView.Registry32);

                localKey.DeleteSubKeyTree(@"SOFTWARE\Classes\CLSID\" + guid, false);
                localKey.DeleteSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\" + guid, false);
                localKey.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var guid = "{497bec52-4c89-4de4-aeb5-334b83bfddec}";
            RemoveFolderFromThisPC(guid, rbLocalMachine.Checked);
        }
    }
}
