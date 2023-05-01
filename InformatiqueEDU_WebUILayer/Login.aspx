<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InformatiqueEDU_WebUILayer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 { width: 90%; height: 100%; margin: 40px; }
        .auto-style2 { text-align: justify; height: 37px; }
        .auto-style3 { width: 21%; 
height: 23px;
            text-align: center;
        }
        .auto-style4 { text-align: justify; height: 37px; width: 352px; }
        .auto-style5 { width: 50%; height: 160px; }
        .auto-style8 { height: 160px; }
        .auto-style9 { width: 188%; height: 23px; }
        .auto-style11 {  }
        .auto-style12 {  z-index: 1; width: 74px; height: 37px; margin: 10px; }
        
        .auto-style13 { width: 100%; }
        .auto-style14 { height: 23px; }
        .auto-style15 {
            width: 86px;
            text-align: center;
        }
        .auto-style19 { z-index: 1; width: 74px; height: 37px; margin: 10px; }
        .auto-style20 { width: 100%;height:100% }
        .auto-style21 { width: 21%; 
height: 25px;
            text-align: center;
        }
        .auto-style22 { width: 188%; height: 25px; }
        .auto-style10 { z-index: 1; }
        .auto-style23 {
            width: 128px;
        }
        .auto-style25 {
            width: 146px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">





                <tr style="background-color: darkslateblue; color: white">
                    <td class="auto-style4">
                        <center><span>Login</span></center>
                    </td>
                    <td class="auto-style2">
                        <center><span>sign in</span></center>
                    </td>
                </tr>





                <tr>
                    <td class="auto-style5">
                        <table class="auto-style20" style="margin: 0px; border:solid 1px black;padding:10px; ">
                            <tr>
                                <td class="auto-style3">Username</td>
                                <td class="auto-style9">
                                    <asp:TextBox ID="LoginUsername" runat="server" CssClass="auto-style10" style="width: 128px"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td class="auto-style21">Password</td>
                                <td class="auto-style22">
                                    <input id="LoginPassword" style="width:128px;" class="auto-style11"  type="password" runat="server"  />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="margin: 10px;">
                                    <center>
                                        <asp:Button ID="Button1" runat="server" CssClass="auto-style12" Style="z-index: 1" Text="Login" OnClick="Login_Click" />
                                    </center>
                                    

                                </td>
                            </tr>
                        </table>
                    </td>





                    <td class="auto-style8" >








                        <table class="auto-style13" style="margin: 0px; border:solid 1px black;padding:10px; ">
                            <tr>
                                <td class="auto-style25">UserName</td>
                                <td>
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="auto-style10" style="width: 128px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25">Fullname</td>
                                <td>
                                    <asp:TextBox ID="txtFullname" runat="server" Style="z-index: 1; width: 128px;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25">Passwrod</td>
                                <td>

                                         <input id="txtPassword"  style="width:128px;" class="auto-style11"  type="password" runat="server"  />


                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style25">confirm password</td>
                                <td>
                                    

                                        <input id="txtPassword2"  class="auto-style23"  type="password" runat="server"  />


                                </td>
                            </tr>


                            <tr>
                                <td class="auto-style15" colspan="2" >
                                          <%= GetStastuLoginApp() %>

                                </td> 
                            </tr>



                            <tr>
                                <td colspan="2">
                                    <center >
                                        <asp:Button ID="Button2" runat="server" CssClass="auto-style19" Text="Sing in" OnClick="btnSingin_Click" />
                                    </center>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td class="auto-style14" colspan="2">&nbsp;</td>
                            </tr>



                        </table>








                    </td>



                </tr>
            </table>
        </div>
        <p>
            &nbsp;
        </p>
    </form>
</body>
</html>
