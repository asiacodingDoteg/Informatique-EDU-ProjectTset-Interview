<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskPage.aspx.cs" Inherits="InformatiqueEDU_WebUILayer.TaskPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Task</title>
    <style>
        ul { list-style-type: none; margin: 0; padding: 0; overflow: hidden; background-color: darkslateblue; }
        li { float: left; }
            li a { display: block; color: white; text-align: center; padding: 14px 16px; text-decoration: none; }
                li a:hover:not(.active) { background-color: #111; }
        .active { background-color: #04AA6D; }

        .HardRecord { width: 400px; border: solid 3px black; height: 140px; border-radius: 20px; padding: 10px; font-display: swap; overflow: hidden }
        .HardRecordDevTitle { padding: 0px; margin: 4px; background-color: mediumorchid; margin: -10px -10px 0px -10px; border-top-left-radius: 18px; border-top-right-radius: 18px; color: white; }
        .HardRecordTitle { float: left; padding: 0px 0px 5px 5px }
        .HardDivTime { float: right; }
        .HardRecordSubject { word-wrap: break-word; }
        .HardRecordButtonOk { position: page; border: solid 1px black; padding: 2px; font-size: 13px; top: 100%; cursor: pointer; }
        .auto-style2 { width: 200px; height: 72px; }
        .auto-style3 { width: 200px; padding: 10px; border-radius: 20px; width: 100%; font-size: 15px }
        .auto-style4 { height: 70px; }
        .auto-style5 {
            text-decoration: underline;
            font-size: large;
        }
        .inpuTtitleStyle{padding: 10px; font-size: 16px; width: 100%; text-align: center}
        .subjectStyle{max-inline-size: stretch; width: 100%; height: 100%;}
        .auto-style6 {
            position: absolute;
            top: 94px;
            left: 838px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 94px;
            left: 838px;
            z-index: 1;
            bottom: 435px;
        }
        .auto-style8 {
            position: absolute;
            top: 152px;
            left: 839px;
        }
        .auto-style9 {
            position: absolute;
            top: 232px;
            left: 839px;
        }
    </style>
</head>
<body>




    <form id="form1" runat="server">

        <div>


            <ul>
                <li style="padding: 10px"><a href="HomePage.aspx">Home</a></li>
                <li style="padding: 10px"><a class="active" href="TaskPage.aspx">Add Task</a></li>
                <li style="padding: 10px"><a href="SearchPage.aspx">Search Task</a></li>
                <li style="float: right; color: white; padding: 10px">
                    <p runat="server" id="LoginUsers">User</p>
                </li>
            </ul>

            <asp:ScriptManager runat="server">
                <CompositeScript>
                </CompositeScript>
            </asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <center>


                        <table>
                            <tr>
                                <td class="auto-style4">
                                    <input   placeholder="Title (The maximum number of characters is 50)" runat="server" id="txtTiteTask" class="auto-style3 inpuTtitleStyle" />
                                </td>
                                <td>

                                    <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTiteTask" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea placeholder="Supject (The maximum number of characters is 500)" runat="server"  id="txtSubjectTask" class="auto-style2 subjectStyle"></textarea>
                                </td>
                                <td>

                        
                              
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSubjectTask" ErrorMessage="*" ForeColor="Red" style="z-index: 1"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:FileUpload ID="upFileTask" runat="server" Width="100%"  />
                                </td>
                                <td>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="border:solid 1px black;padding:5px;">
                                        <span class="auto-style5"><strong>currently available users</strong></span>
                                        <asp:RadioButtonList ID="GetCurUsers1" runat="server"></asp:RadioButtonList>
                                    </div>
                                </td>
                                <td>

                                    <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator5" runat="server" ControlToValidate="GetCurUsers1"  ErrorMessage="*" style="z-index: 1"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button Text="Save" CssClass="auto-style3" runat="server" OnClick="SaveTask_Click" />
                                </t>
                            </tr>

                             <tr>
                                <td colspan="2">
                                    <span runat="server" id="msgErorrinPage"></span>
                                </t>
                            </tr>

                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>





        </div>
    </form>
</body>
</html>
