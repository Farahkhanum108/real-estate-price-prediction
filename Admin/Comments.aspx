﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="Comments.aspx.cs" Inherits="pricePrediction.Admin.Comments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

 <div class="container">

        
          <h2>VIEW TOPIC COMMENTS !</h2>
        <hr class="colorgraph">

      
      
      <br />
      
        <table align="center" style="width: 96%;">
            <tr style="font-size: small">
                <td>
                    <asp:Label ID="lblTopic" runat="server" Font-Bold="True" Font-Size="Large" 
                        ForeColor="#990000"></asp:Label>
                </td>
            </tr>
            <tr style="font-size: small">
                <td>
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
