<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="InformatiqueEDU_WebUILayer.SearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
            <ul>
                <li style="padding: 10px"><a href="HomePage.aspx">Home</a></li>
                <li style="padding: 10px"><a href="TaskPage.aspx">Add Task</a></li>
                <li style="padding: 10px"><a class="active" href="SearchPage.aspx">Search Task</a></li>
                <li style="float: right; color: white; padding: 10px">
                    <p runat="server" id="LoginUsers">User</p>
                </li>
            </ul>
             



        </div>
    </form>
</body>
</html>
