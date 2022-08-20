<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMP.Master" AutoEventWireup="true" CodeBehind="PriceNB.aspx.cs" Inherits="pricePrediction.Admin.Files.PriceNB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
    <!-- Start contact Area -->  
   <div class="container">          
<br />  
<h2>PRICE PREDICTION</h2>
<hr class="colorgraph">
         <br />
 <div style="height:250px; width:auto; overflow:auto">

  
 <h3>Testing Dataset</h3>


<asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" 
         BorderColor="#DEBA84" BorderWidth="1px" CellPadding="3" BorderStyle="None" 
         CellSpacing="2">

    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    <PagerStyle ForeColor="#8C4510" 
        HorizontalAlign="Center" />
    <RowStyle ForeColor="#8C4510" BackColor="#FFF7E7" />
    <SelectedRowStyle BackColor="#738A9C" ForeColor="White" Font-Bold="True" />
    <SortedAscendingCellStyle BackColor="#FFF1D4" />
    <SortedAscendingHeaderStyle BackColor="#B95C30" />
    <SortedDescendingCellStyle BackColor="#F1E5CE" />
    <SortedDescendingHeaderStyle BackColor="#93451F" />

</asp:GridView>
</div>
          <br />
          
           <h2><span>PRICE </span> PREDICTION USING BAYESIAN CLASSIFIER!!!</h2>
          <hr />
            <br />

          <asp:Button ID="btnPrediction" runat="server" 
                      Text="Predict Output" 
              onclick="btnPrediction_Click" CssClass="btn" Height="50px" Width="150px" /> &nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnResults" runat="server" CssClass="btn" 
              onclick="btnResults_Click" Text="Result Analysis" Height="50px" 
              Width="150px" />
          <br /><br /><div>
      <asp:Table ID="tablePrediction" runat="server">
      </asp:Table>
      </div>
          <br />
        

     

        <!-- End col-->
      </div>

  <!-- End Contact Area -->


    </asp:Panel>
</asp:Content>
