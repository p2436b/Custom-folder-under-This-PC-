using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace ThisPC
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private readonly string FOLDER_GUID = Guid.NewGuid().ToString("B").ToUpper();

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (AddFolderToThisPC(
          FOLDER_GUID,
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

    private void btnDelete_Click(object sender, EventArgs e)
    {
      var inputBox = new InputBox();
      if (inputBox.ShowDialog() == DialogResult.OK)
        if (Guid.TryParse(inputBox.txtGuid.Text, out var guid))
        {
          RemoveFolderFromThisPC(guid.ToString("B").ToUpper());
          MessageBox.Show("Deleted successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
          MessageBox.Show("Invalid GUID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    /// <summary>
    /// Add a folder in the Windows explorer to Devices and drives
    /// </summary>
    /// <param name="guid">A GUID for registery key</param>
    /// <param name="folderName">Name of the folder in the Windows explorer</param>
    /// <param name="folderPath">Path of the folder in the Windows explorer</param>
    /// <param name="tooltip">Tooltip of the folder in the Windows explorer</param>
    /// <param name="iconPath">Icon pah of the folder in the Windows explorer</param>
    /// <returns>True if succeed, False if failure</returns>
    public bool AddFolderToThisPC(string guid, string folderName, string folderPath, string tooltip, string iconPath)
    {
      try
      {
        RegistryKey localKey, keyTemp, rootKey;

        localKey = Environment.Is64BitOperatingSystem
            ? RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
            : RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);

        // 32bit or 64bit
        rootKey = localKey.CreateSubKey(@"Software\Classes\CLSID\" + guid);
        rootKey.SetValue("", folderName, RegistryValueKind.String);
        rootKey.SetValue("Infotip", tooltip, RegistryValueKind.String);
        //rootKey.SetValue("DescriptionID", unchecked(0x4), RegistryValueKind.DWord);
        rootKey.SetValue("System.IsPinnedToNameSpaceTree", unchecked(0x1), RegistryValueKind.DWord);

        keyTemp = rootKey.CreateSubKey("DefaultIcon");
        keyTemp.SetValue("", iconPath, RegistryValueKind.ExpandString);
        keyTemp.Close();

        keyTemp = rootKey.CreateSubKey("InProcServer32");
        keyTemp.SetValue("", @"%SYSTEMROOT%\system32\shdocvw.dll", RegistryValueKind.ExpandString);
        keyTemp.SetValue("ThreadingModel", "Both", RegistryValueKind.String);
        keyTemp.Close();

        keyTemp = rootKey.CreateSubKey("Instance");
        keyTemp.SetValue("CLSID", "{0AFACED1-E828-11D1-9187-B532F1E9575D}", RegistryValueKind.String);
        keyTemp.Close();

        keyTemp = rootKey.CreateSubKey(@"Instance\InitPropertyBag");
        keyTemp.SetValue("Target", folderPath, RegistryValueKind.ExpandString);
        keyTemp.Close();

        keyTemp = rootKey.CreateSubKey("ShellFolder");
        keyTemp.SetValue("Attributes", unchecked((int)0xf080004d), RegistryValueKind.DWord);
        keyTemp.SetValue("WantsFORPARSING", "", RegistryValueKind.String);
        keyTemp.SetValue("HideAsDeletePerUser", "", RegistryValueKind.String);
        keyTemp.Close();

        if (Environment.Is64BitOperatingSystem)
        {
          // WOW6432Node
          rootKey = localKey.CreateSubKey(@"Software\Classes\WOW6432Node\CLSID\" + guid);
          rootKey.SetValue("", folderName, RegistryValueKind.String);
          rootKey.SetValue("Infotip", tooltip, RegistryValueKind.String);
          //rootKey.SetValue("DescriptionID", unchecked(0x4), RegistryValueKind.DWord);
          rootKey.SetValue("System.IsPinnedToNameSpaceTree", unchecked(0x1), RegistryValueKind.DWord);

          keyTemp = rootKey.CreateSubKey("DefaultIcon");
          keyTemp.SetValue("", iconPath, RegistryValueKind.ExpandString);
          keyTemp.Close();

          keyTemp = rootKey.CreateSubKey("InProcServer32");
          keyTemp.SetValue("", @"%SYSTEMROOT%\system32\shdocvw.dll", RegistryValueKind.ExpandString);
          keyTemp.SetValue("ThreadingModel", "Both", RegistryValueKind.String);
          keyTemp.Close();

          keyTemp = rootKey.CreateSubKey("Instance");
          keyTemp.SetValue("CLSID", "{0AFACED1-E828-11D1-9187-B532F1E9575D}", RegistryValueKind.String);
          keyTemp.Close();

          keyTemp = rootKey.CreateSubKey(@"Instance\InitPropertyBag");
          keyTemp.SetValue("Target", folderPath, RegistryValueKind.ExpandString);
          keyTemp.Close();

          keyTemp = rootKey.CreateSubKey("ShellFolder");
          keyTemp.SetValue("Attributes", unchecked((int)0xf080004d), RegistryValueKind.DWord);
          keyTemp.SetValue("WantsFORPARSING", "", RegistryValueKind.String);
          keyTemp.SetValue("HideAsDeletePerUser", "", RegistryValueKind.String);
          keyTemp.Close();
        }

        // Add to explorer
        keyTemp = localKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\" + guid);
        keyTemp.Close();

        localKey.Close();
        rootKey.Close();
        MessageBox.Show(guid);
        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// Remove folde from the Windows explorer
    /// </summary>
    /// <param name="guid">The folder GUID in registery key</param>
    /// <returns>True if succeed, False if failure</returns>
    public bool RemoveFolderFromThisPC(string guid)
    {
      try
      {
        var localKey = Environment.Is64BitOperatingSystem
            ? RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
            : RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);

        localKey.DeleteSubKeyTree(@"Software\Classes\CLSID\" + guid, false);
        localKey.DeleteSubKeyTree(@"Software\Classes\WOW6432Node\CLSID\" + guid, false);
        localKey.DeleteSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\MyComputer\NameSpace\" + guid, false);
        localKey.Close();
        return true;
      }
      catch
      {
        return false;
      }
    }

    private void btnAddSidebar_Click(object sender, EventArgs e)
    {
      if (AddFolderToExplorerSidebar(
    FOLDER_GUID,
    txtFolderName.Text,
    txtFolderPath.Text,
    txtFolderIconPath.Text))
      {
        MessageBox.Show("Added");
      }
      else
      {
        MessageBox.Show("Error");
      }
    }

    public bool AddFolderToExplorerSidebar(string guid, string folderName, string folderPath, string iconPath)
    {
      try
      {
        RegistryKey localKey, keyTemp, rootKey;

        localKey = Environment.Is64BitOperatingSystem
            ? RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
            : RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);

        // 32bit or 64bit
        rootKey = localKey.CreateSubKey(@"Software\Classes\CLSID\" + guid);
        rootKey.SetValue("", folderName, RegistryValueKind.String);
        rootKey.SetValue("SortOrderIndex", unchecked(0x42), RegistryValueKind.DWord);
        rootKey.SetValue("System.IsPinnedToNameSpaceTree", unchecked(0x1), RegistryValueKind.DWord);

        keyTemp = rootKey.CreateSubKey("DefaultIcon");
        keyTemp.SetValue("", iconPath, RegistryValueKind.ExpandString);
        keyTemp.Close();

        keyTemp = rootKey.CreateSubKey("InProcServer32");
        keyTemp.SetValue("", @"%SYSTEMROOT%\system32\shdocvw.dll", RegistryValueKind.ExpandString);
        keyTemp.SetValue("ThreadingModel", "Both", RegistryValueKind.String);
        keyTemp.Close();

        keyTemp = rootKey.CreateSubKey("Instance");
        keyTemp.SetValue("CLSID", "{0AFACED1-E828-11D1-9187-B532F1E9575D}", RegistryValueKind.String);
        keyTemp.Close();

        keyTemp = rootKey.CreateSubKey(@"Instance\InitPropertyBag");
        keyTemp.SetValue("Attributes", unchecked(0x11), RegistryValueKind.DWord);
        keyTemp.SetValue("Target", folderPath, RegistryValueKind.ExpandString);
        keyTemp.Close();

        keyTemp = rootKey.CreateSubKey("ShellFolder");
        keyTemp.SetValue("Attributes", unchecked((int)0xf080004d), RegistryValueKind.DWord);
        keyTemp.SetValue("FolderValueFlags", unchecked(0x28), RegistryValueKind.DWord);
        keyTemp.Close();

        if (Environment.Is64BitOperatingSystem)
        {
          // WOW6432Node
          rootKey = localKey.CreateSubKey(@"Software\Classes\WOW6432Node\CLSID\" + guid);
          rootKey.SetValue("", folderName, RegistryValueKind.String);
          rootKey.SetValue("SortOrderIndex", unchecked(0x42), RegistryValueKind.DWord);
          rootKey.SetValue("System.IsPinnedToNameSpaceTree", unchecked(0x1), RegistryValueKind.DWord);

          keyTemp = rootKey.CreateSubKey("DefaultIcon");
          keyTemp.SetValue("", iconPath, RegistryValueKind.ExpandString);
          keyTemp.Close();

          keyTemp = rootKey.CreateSubKey("InProcServer32");
          keyTemp.SetValue("", @"%SYSTEMROOT%\system32\shdocvw.dll", RegistryValueKind.ExpandString);
          //keyTemp.SetValue("ThreadingModel", "Both", RegistryValueKind.String);
          keyTemp.Close();

          keyTemp = rootKey.CreateSubKey("Instance");
          keyTemp.SetValue("CLSID", "{0AFACED1-E828-11D1-9187-B532F1E9575D}", RegistryValueKind.String);
          keyTemp.Close();

          keyTemp = rootKey.CreateSubKey(@"Instance\InitPropertyBag");
          keyTemp.SetValue("Attributes", unchecked(0x11), RegistryValueKind.DWord);
          keyTemp.SetValue("TargetFolderPath", folderPath, RegistryValueKind.ExpandString);
          keyTemp.Close();

          keyTemp = rootKey.CreateSubKey("ShellFolder");
          keyTemp.SetValue("Attributes", unchecked((int)0xf080004d), RegistryValueKind.DWord);
          keyTemp.SetValue("FolderValueFlags", unchecked(0x28), RegistryValueKind.DWord);
          keyTemp.Close();
        }

        // Add to explorer
        keyTemp = localKey.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\" + guid);
        keyTemp.SetValue("", folderName, RegistryValueKind.String);
        keyTemp.Close();

        keyTemp = localKey.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel", true);
        keyTemp.SetValue(guid, unchecked(0x1), RegistryValueKind.DWord);
        keyTemp.Close();

        localKey.Close();
        rootKey.Close();
        MessageBox.Show(guid);
        return true;
      }
      catch
      {
        return false;
      }
    }

    public bool RemoveFolderFromExplorerSidebar(string guid)
    {
      RegistryKey localKey, keyTemp;
      try
      {
        localKey = Environment.Is64BitOperatingSystem
            ? RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64)
            : RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32);

        keyTemp = localKey.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel", true);
        keyTemp.DeleteValue(guid, false);
        keyTemp.Close();

        localKey.DeleteSubKeyTree(@"Software\Classes\CLSID\" + guid, false);
        localKey.DeleteSubKeyTree(@"Software\Classes\WOW6432Node\CLSID\" + guid, false);
        localKey.DeleteSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\" + guid, false);

        localKey.Close();
        return true;
      }
      catch
      {
        return false;
      }
    }

    private void btnDeleteSidebar_Click(object sender, EventArgs e)
    {
      var inputBox = new InputBox();
      if (inputBox.ShowDialog() == DialogResult.OK)
        if (Guid.TryParse(inputBox.txtGuid.Text, out var guid))
        {
          RemoveFolderFromExplorerSidebar(guid.ToString("B").ToUpper());
          MessageBox.Show("Deleted successfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
          MessageBox.Show("Invalid GUID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}
