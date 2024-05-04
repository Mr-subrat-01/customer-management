<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table border="1" align="center">
            <tr>
                <th colspan="2">Customer Form</th>
            </tr>
            <tr>
                <td>Enter Customer Name</td>
                <td>
                    <asp:TextBox runat="server" ID="txtCustName"></asp:TextBox>
                <asp:Label ID="txtCustId" runat="server" Text="" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Enter Customer Email</td>
                <td>
                    <asp:TextBox runat="server" ID="txtCustEmail"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Enter Customer Phone</td>
                <td>
                    <asp:TextBox runat="server" ID="txtCustPhone"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Enter Customer Address</td>
                <td>
                    <asp:TextBox runat="server" ID="txtCustAdd"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblMsg"></asp:Label>
                </td>
                <td>
                    <asp:Button Text="Insert" ID="insertBtn" runat="server" OnClientClick="return Validate()"  OnClick="insertBtn_Click"/>
                    <asp:Button Text="Update" ID="updateBtn" runat="server" OnClientClick="return Validate()"  OnClick="updateBtn_Click"/>
                    <asp:Button Text="Delete" ID="deleteBtn" runat="server" OnClientClick="return Validate()" OnClick="deleteBtn_Click" />
                    <asp:Button Text="Reset Form" ID="resetBtn" runat="server" OnClick="resetBtn_Click" />
                </td>
            </tr>
            <tr align="center">
                <th colspan="2">Customer Records</th>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="custid" HeaderText="Customer ID"></asp:BoundField>
                            <asp:BoundField DataField="custName" HeaderText="Customer Name"></asp:BoundField>
                            <asp:BoundField DataField="custEmail" HeaderText="Customer Email"></asp:BoundField>
                            <asp:BoundField DataField="custPhone" HeaderText="Customer Phone"></asp:BoundField>
                            <asp:BoundField DataField="custAdd" HeaderText="Customer Address"></asp:BoundField>
                            <asp:CommandField ShowSelectButton="True">

                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
    <script>
        function Validate() {
            var custName = document.getElementById("txtCustName");
            var custEmail = document.getElementById("txtCustEmail");
            var custPhone = document.getElementById("txtCustPhone");
            var custAdd = document.getElementById("txtCustAdd");
            console.log(custName);
            if (custName.value.length == 0) {
                alert("Customer Name should not Blank !");
                custName.focus();
                return false;
            }
            var expEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!custEmail.value.match(expEmail)) {
                alert("Customer Email is Invalid !")
                custEmail.focus();
                return false;
            }

            var expPhone = /^[0-9]+$/;
            if (!custPhone.value.match(expPhone)) {
                alert("Customer Phone Contain only Digits !")
                custPhone.focus();
                return false;
            }

            var expAdd = /^[a-zA-Z0-9 \-\,\:]+$/;
            if (!custAdd.value.match(expAdd)) {
                alert("Customer Address is Invalid !");
                custAdd.focus();
                return false;
            }
            return true;
        }
    </script>
</body>
</html>
