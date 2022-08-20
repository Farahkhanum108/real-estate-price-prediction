<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="Topics.aspx.cs" Inherits="pricePrediction.Admin.Topics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

 <div class="container">
 <br /> 

       
            <h2>DISCUSSION FORM (TOPICS) !</h2>
        
        <hr class="colorgraph">
     
    
      <br />
        <table align="center" style="width: 95%;">
            <tr style="font-size: small">
                <td align="left">
                
                         <div style="height:400px; width:auto; overflow:auto">
                    <asp:Table ID="Table1" runat="server">
                    </asp:Table>
                    </div>
                </td>
            </tr>
        </table>

        
        </div>
        <br />
      
   <br />
    </asp:Panel>
</asp:Content>
