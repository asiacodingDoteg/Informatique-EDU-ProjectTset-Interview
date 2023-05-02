<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="InformatiqueEDU_WebUILayer.SearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Task</title>
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
        .auto-style1 { width: 291px; height: 36px; text-align: center; }
        .auto-style2 { width: 50%; height: 36px; text-align: center; }
        .auto-style3 { height: 50%; text-align: center; }
        .auto-style7 { text-align: center; }
        .auto-style9 { font-size: large; font-weight: bold; font-family: "Agency FB"; height: 20px; width: 80%; }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>

            <ul>
                <li style="padding: 10px"><a href="HomePage.aspx">Home</a></li>

                <%
                    if (InformatiqueEDU_WebUILayer.ExtensionMethod.CurUser(this).UserType == 1) //See Only Task ( Admin ) no normal Users
                    {
                        Response.Write("<li style='padding: 10px;'><a href='TaskPage.aspx'>Add Task</a></li>");
                    }
                %>
                <li style="padding: 10px"><a class="active" href="SearchPage.aspx">Task</a></li>
                <li style="float: right; color: white; padding: 10px">
                    <p runat="server" id="LoginUsers"></p>
                </li>
            </ul>


            <asp:ScriptManager runat="server">
                <CompositeScript></CompositeScript>
            </asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Panel runat="server" ID="PlControlData">
                        <div class="auto-style7" runat="server" id="Panel">

                            <div style="background-color: darkslateblue; padding: 10px; border-end-start-radius: 20px; border-end-end-radius: 20px;">
                                <input class="auto-style9" placeholder="Search for tasks" style="background-color: darkslateblue; color: white; border: solid 0px; border-block-end: solid 1px black; text-align: center;" id="txtSharch" runat="server" />
                                <br />
                                &nbsp;<div>
                                    <asp:Button runat="server" Text="Sharch" OnClick="Sharch" />
                                </div>
                            </div>

                            <br />

                            <center>
                                <asp:DataList runat="server" ID="ViewControlListTask" BorderColor="Black" BorderWidth="1px" CellPadding="1" CellSpacing="1" style="width: 100%">
                                    <itemtemplate>
                                        <div style="border: solid 1px black; margin: 4px; border-radius: 10px; padding: 5px;">
                                            Name : <%# Eval("Fullname") %>
                                            <br />
                                            Stuts Task : <%# Eval("Status").ToString() == "1" ? "Been completed" : "Under implementation" %>
                                            <br />
                                            <a href="SearchPage?OD=<%# Eval("ID") %>">Click here to go to the details</a>
                                        </div>
                                    </itemtemplate>
                                </asp:DataList>
                            </center>

                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>

            <center>
                <table runat="server" id="TabDelest">
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lblTameLaderName" runat="server" Style="z-index: 1" Text="TeamLoader :"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="lblDataTask" runat="server" Style="z-index: 1" Text="Last Update :"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="auto-style7">
                            <asp:Label runat="server" Style="z-index: 1" Text="Title"></asp:Label>
                            <br />
                            <input id="txtTitle" runat="server" type="text" style="width: 100%; height: 40px; font-size: medium" /></td>
                    </tr>


                    <tr>
                        <td colspan="2" class="auto-style7">
                            <asp:Label runat="server" Style="z-index: 1" Text="Subject" ID="Label3"></asp:Label>
                            <br />
                            <textarea id="txtSubject" runat="server" style="width: 100%; height: 40px; font-size: medium" ></textarea>
                        </td>
                    </tr>


                    <tr>
                        <td colspan="2" class="auto-style7">
                            <asp:Button ID="btnDownlaodData" runat="server" Text="Download the attachment" Height="26px" Width="215px" OnClick="btnDownlaodData_Click" />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <div runat="server">

                                <center>
                                    Status Task
                                    <asp:RadioButtonList ID="rblStautsTask" runat="server" BorderStyle="Solid" RepeatColumns="1" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">Been completed</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">Under implementation</asp:ListItem>
                                    </asp:RadioButtonList>
                                </center>

                            </div>
                        </td>
                    </tr>


                    <tr>
                        <td class="auto-style3" colspan="2">
                            <asp:Button ID="btnSaveData" runat="server" Text="Save" Height="40px" Width="108px" OnClick="btnSaveData_Click" />
                        </td>
                    </tr>
                </table>
            </center>




        </div>
    </form>


</body>
</html>
