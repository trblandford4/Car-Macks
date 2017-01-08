Namespace My
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            CreateBrowserKey()
        End Sub

        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            ' I don't like applications that defecate in the registry and then don't cleanup their own mess
            ' so remove the key
            RemoveBrowserKey()
        End Sub

        Private Const BrowserKeyPath As String = "\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"

        Private Sub CreateBrowserKey(Optional ByVal IgnoreIDocDirective As Boolean = False)
            Dim basekey As String = Microsoft.Win32.Registry.CurrentUser.ToString
            Dim value As Int32
            Dim thisAppsName As String = My.Application.Info.AssemblyName & ".exe"

            ' Value reference: http://msdn.microsoft.com/en-us/library/ee330730%28v=VS.85%29.aspx
            ' IDOC Reference:  http://msdn.microsoft.com/en-us/library/ms535242%28v=vs.85%29.aspx
            Select Case (New WebBrowser).Version.Major
                Case 8
                    If IgnoreIDocDirective Then
                        value = 8888
                    Else
                        value = 8000
                    End If

                Case 9
                    If IgnoreIDocDirective Then
                        value = 9999
                    Else
                        value = 9000
                    End If
                Case 10
                    If IgnoreIDocDirective Then
                        value = 10001
                    Else
                        value = 10000
                    End If

                Case 11

                    If IgnoreIDocDirective Then
                        value = 11001
                    Else
                        value = 11000
                    End If

                Case Else
                    Exit Sub

            End Select

            Microsoft.Win32.Registry.SetValue(Microsoft.Win32.Registry.CurrentUser.ToString & BrowserKeyPath,
                                              Process.GetCurrentProcess.ProcessName & ".exe",
                                              value,
                                              Microsoft.Win32.RegistryValueKind.DWord)
        End Sub

        Private Sub RemoveBrowserKey()
            Dim key As Microsoft.Win32.RegistryKey
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(BrowserKeyPath.Substring(1), True)
            key.DeleteValue(Process.GetCurrentProcess.ProcessName & ".exe", False)
        End Sub
    End Class 'MyApplication

End Namespace 'My