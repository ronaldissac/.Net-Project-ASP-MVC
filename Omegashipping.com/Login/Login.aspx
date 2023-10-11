 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Omegashipping.com.Login.Login1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.1.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="Login.css" />
</head>
<body>
    <div class="header">
        <div>
            <img src="Logo.png" height="60" width="150" />
        </div>
        <div>
            <h1>Omega Shipping Agency PVT LTD</h1>
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <div class="card track-section">
                        <h2 class="text-center">Track Details</h2>
                        <div class="mb-3">
                            <asp:TextBox ID="Track" runat="server" CssClass="form-control" ValidationGroup="Tracking" placeholder="Track"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="TrackRequired" runat="server" ControlToValidate="Track" ValidationGroup="Tracking" ErrorMessage="Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                           <div class="text-center">
                               <asp:Button ID="TrackButton" runat="server" Text="Track" OnClick="TrackButton_Click" ValidationGroup="Tracking" CssClass="btn btn-primary" />
                        </div>     
                        </div>
                        <div class="text-center">
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="card login-section">
                        <h2 class="text-center">Login</h2>
                        <div class="mb-3">
                            <select class="dropdown" id="UserTypeDropdown" runat="server">
                            <option value="Admin">Admin</option>
                            <option value="User">User</option>
                        </select>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="UserID" runat="server" CssClass="form-control" placeholder="UserID"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserID" ValidationGroup="SubmitValidation" ErrorMessage="Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control" OnTextChanged="LoginButton_Click" ValidationGroup="SubmitValidation" placeholder="Password" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ValidationGroup="SubmitValidation" ErrorMessage="Required" CssClass="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="text-center">
                            <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary" OnClick="LoginButton_Click" ValidationGroup="SubmitValidation" Text="Login" />
                            <p><asp:Label ID="LoginResultLabel" runat="server" Visible="false"></asp:Label></p>
                        </div>
                    </div>
                </div>
            </div>
            <br class="Apple-interchange-newline">
        </div>
        <div>
        <div class="container mt-5" id="gridViewContainer">
            <div class="row">
                <div class="col">
                    <div class="card gridview-container">
                        <div class="card-header">Tracking Details</div>
                        <div class="card-body">
                            <asp:GridView ID="GridView"  runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
                                <Columns>
                                    <asp:BoundField DataField="FromLocation" HeaderText="From Location" />
                                    <asp:BoundField DataField="ToLocation" HeaderText="To Location" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:BoundField DataField="Location" HeaderText="Current Location" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            </div>
    </form>
    
   <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.1.0/js/bootstrap.bundle.min.js">

    </script>
    <!-- Add these script tags before your JavaScript code -->
<script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-oX1znXb1MuPO9XTPyYk6LtPEJ5hXMf8uO/mZPex/Lfw=" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-ajax-unobtrusive/3.2.6/jquery.unobtrusive-ajax.min.js" integrity="sha512-xnoavtDoRTH2v3MjlRQ6Id0QxFc9pNJgbunHp66hNbjEOTCvSdo0S5n26krQj9fyi/yd1/4aY38GRkF+YnQuA==" crossorigin="anonymous"></script>

    
    <script>
         // Get Browser Version
        function getBrowserVersion() {
            const userAgent = navigator.userAgent;
            const browserInfo = userAgent.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || [];
            const browserName = browserInfo[1].toLowerCase();
            const browserVersion = browserInfo[2];

            return `${browserName} ${browserVersion}`;
        }

        // Get Time and Date
        function getTimeAndDate() {
            const now = new Date();
            const time = now.toLocaleTimeString();
            const date = now.toLocaleDateString();

            return { time, date };
        }

        // Display the results in the footer
        document.addEventListener('DOMContentLoaded', function () {
            const browserVersion = getBrowserVersion();
            const { time, date } = getTimeAndDate();

            document.getElementById('browser-version').innerText = `Browser Version: ${browserVersion}`;
            document.getElementById('time').innerText = `Time: ${time}`;
            document.getElementById('date').innerText = `Date: ${date}`;
        });

        //function showGridView() {
        //    const gridViewContainer = document.getElementById('gridViewContainer');
        //    gridViewContainer.style.display = gridViewContainer.style.display === 'none' ? 'block' : 'none';
        //}
        
    </script>
</body>

</html>
