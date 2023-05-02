<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="InformatiqueEDU_WebUILayer.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>

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

    <style>
        /* global variables */
        :root { /* width */ --componentWidth: 736px; /* color */ --color0: #ffffff; --color1: #ebf1ff; --color2: #c8c7ff; --color2Trans: #c8c7ff99; --color3: #303b5a; --color3Trans: #303b5a99; --color4: #ff5757; --color4Trans: #ff57570d; --color5: #ffb01f; --color5Trans: #ffb01f0d; --color6: #00bd91; --color6Trans: #00bd910d; --color7: #1125d4; --color7Trans: #1125d40d; /* gradient */ --backgroundGradient: linear-gradient(180deg, #7857ff 0%, #2e2be9 100%); --circleGradient: linear-gradient(180deg, #4e21ca 0%, #2421ca00 100%); /* font size */ --fontSizeGlobalValue: 18px; /* font weight */ --mediumFont: 500; --boldFont: 700; --extraBoldFont: 800; }

        /* reset default settings */
        * { box-sizing: border-box; }

        ::selection { background-color: var(--color2); color: var(--color3); }



        .componentContainer { width: var(--componentWidth); height: 512px; border-radius: 25px; overflow: hidden; box-shadow: rgb(200 199 255 / 50%) 0 0 20px; display: flex; }


        /* result | start */
        .result { background-image: var(--backgroundGradient); width: 50%; padding: 45px 70px; border-radius: inherit; }

        .result__title { color: var(--color2); /* typography */ font-size: 21px; font-weight: var(--boldFont); text-align: center; letter-spacing: 1px; }

        .result__circle { background-image: var(--circleGradient); width: 200px; height: 200px; margin: 30px auto 35px; border-radius: 50%; /* flex */ display: flex; flex-direction: column; justify-content: center; align-items: center; }

        .result__circleDigits { color: var(--color0); margin-bottom: 5px; /* typography */ font-size: 70px; font-weight: var(--extraBoldFont); }

        .result__circleText { color: var(--color2Trans); }

        .result__messageHeadline { color: var(--color0); margin-bottom: 20px; /* typography */ font-size: 30px; font-weight: var(--boldFont); text-align: center; letter-spacing: 0.5px; }

        .result__messageDetails { color: var(--color2); font-size: 16px; /* typography */ text-align: center; line-height: 1.5; }
        /* result | end */


        /* summary | start */
        .summary { width: 50%; padding: 45px 40px; border-radius: inherit; }

        .summary__title { color: var(--color3); margin-bottom: 35px; /* typography */ font-size: 22px; font-weight: var(--boldFont); }

        .summary__states { /* flex */ display: flex; flex-direction: column; }

        .summary__state { width: 100%; padding: 20px; border-radius: 10px; /* flex */ display: flex; justify-content: space-between; align-items: center; }

            .summary__state:not(.summary__state:last-of-type) { margin-bottom: 18px; }

        .summary__stateLabel { display: flex; }

        .summary__stateName { margin-left: 10px; }

        .summary__stateDigits { display: flex; }

        .summary__stateTDigitsValue { color: var(--color3); font-weight: var(--boldFont); }

        .summary__stateDigitsTotal { color: var(--color3Trans); font-weight: var(--mediumFont); margin-left: 6px; }

        .summary__button { background-image: var(--backgroundGradient); color: var(--color0); width: 100%; padding: 18px; margin-top: 40px; overflow: hidden; transition: transform 0.05s; cursor: pointer; /* position */ position: relative; z-index: 0; /* border */ border: navajowhite; border-radius: 50px; }

            .summary__button:active { transform: scale(0.95); }

        .summary__buttonOverlay { background-color: var(--color3); width: 100%; height: 100%; opacity: 1; transition: opacity 0.5s; /* position */ position: absolute; top: 0; left: 0; z-index: 1; }

        .summary__button:hover .summary__buttonOverlay { opacity: 0; }

        .summary__buttonText { /* position */ position: relative; z-index: 2; /* typography */ font-size: 18px; font-weight: var(--boldFont); letter-spacing: 0.5px; }
        /* summary | end */


        /* media queries | start */
        @media (min-width: 610px) and (max-width: 800px) {
            .componentContainer { transform: scale(0.75); }
        }

        @media (max-width: 610px) {
            body { padding: 0; }

            .componentContainer { width: 100vw; height: auto; border-radius: 0 0 25px 25px; box-shadow: none; flex-direction: column; }

            .result { width: auto; padding: 30px 30px 35px; border-radius: 0 0 50px 50px; }

            .result__circle { margin: 20px auto; transform: scale(0.85); }

            .result__message { transform: scale(0.95); }

            .result__messageHeadline { margin-bottom: 15px; }

            .result__messageDetails { max-width: 270px; margin: 0 auto; }

            .summary { width: auto; }
        }

        @media (max-width: 475px) {
            .result__title { font-size: 20px; }

            .summary { padding: 45px 20px; }
        }
        /* media queries | end */
    </style>



</head>
<body>




    <form id="form1" runat="server">

        <div>


            <ul>
                <li style="padding: 10px;"><a class="active" href="HomePage.aspx">Home</a></li>

                <%
                    if (InformatiqueEDU_WebUILayer.ExtensionMethod.CurUser(this).UserType == 1) //See Only Task to Admin
                    {
                        Response.Write("<li style='padding: 10px;'><a href='TaskPage.aspx'>Add Task</a></li>");
                    }
                %>
                

                <li style="padding: 10px;"><a href="SearchPage.aspx">Task</a></li>


                <li style="float: right; color: white; padding: 10px">
                    <p runat="server" id="LoginUsers">User</p>
                </li>
            </ul>


            <br />






            <asp:ScriptManager runat="server">
                <CompositeScript></CompositeScript>
            </asp:ScriptManager>
            <asp:UpdatePanel runat="server" ID="up1">
                <ContentTemplate>
                    <div>
                        <center>
                            <%=CopyLinkProfiler() %>
                            <div class='componentContainer'>
                                <div class='result'>
                                    <%=BasicdataAnalysis() %>
                                </div>
                                <div class='summary'>
                                    <p class='summary__title'><%=SeeWelcomeMSG() %> </p>
                                    <%= SetTaskRes() %>
                                    <%= SetUserCount() %>
                                </div>
                            </div>
                    </div>
                    </center>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>





        </div>
    </form>






</body>
</html>
