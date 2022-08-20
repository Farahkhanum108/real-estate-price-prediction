<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MemberMP.Master" AutoEventWireup="true" CodeBehind="HousePrice.aspx.cs" Inherits="pricePrediction.Member.HousePrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">
    
<div class="container">
<br />

<h2>HOUSE PRICE </h2>
<hr class="colorgraph">


			<div class="form-group">

            <asp:TextBox class="form-control input-lg" placeholder="Enter AreaType" tabindex="4" ID="txtareaType" runat="server" Width=50%></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Enter AreaType" ControlToValidate="txtareaType" 
                    CssClass="validation" ToolTip="Enter AreaType" ValidationGroup="a">Enter AreaType</asp:RequiredFieldValidator>
                    Super built-up  Area(1), Plot  Area(2), Built-up  Area (3)
				
			</div>
			<div class="form-group">
				<asp:TextBox class="form-control input-lg" placeholder="Enter Size" 
                    tabindex="4" ID="txtSize" runat="server" Width=50%></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Enter Size" ControlToValidate="txtSize" 
                    CssClass="validation" ToolTip="Enter Size" ValidationGroup="a">Enter Size</asp:RequiredFieldValidator>
                     2 BHK, 3BHK ....

			</div>

			<div class="form-group">

            <asp:TextBox class="form-control input-lg" placeholder="Enter TotalSqFeet" tabindex="4" ID="txtTotalSqFeet" runat="server" Width=50%></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Enter TotalSqFeet" ControlToValidate="txtTotalSqFeet" 
                    CssClass="validation" ToolTip="Enter TotalSqFeet" ValidationGroup="a">Enter TotalSqFeet</asp:RequiredFieldValidator>
                    square feet
				
			</div>

            <div class="form-group">

            <asp:TextBox class="form-control input-lg" placeholder="Enter Bath" tabindex="4" ID="txtBath" runat="server" Width=50%></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Enter Bath" ControlToValidate="txtBath" 
                    CssClass="validation" ToolTip="Enter Bath" ValidationGroup="a">Enter Bath</asp:RequiredFieldValidator>		
                    number (1,2 , 3....)					    				
			</div>

            <div class="form-group">

            <asp:TextBox class="form-control input-lg" placeholder="Enter Balcony" tabindex="4" ID="txtBalcony" runat="server" Width=50%></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Enter Balcony" ControlToValidate="txtBalcony" 
                    CssClass="validation" ToolTip="Enter Balcony" ValidationGroup="a">Enter Balcony</asp:RequiredFieldValidator>
				
			  count 1,2,3 ...
				
			</div>



             <div class="form-group">

            <asp:TextBox class="form-control input-lg" placeholder="Enter road_access" tabindex="4" ID="txtroad_access" runat="server" Width=50%></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="Enter road_access" ControlToValidate="txtroad_access" 
                    CssClass="validation" ToolTip="Enter road_access" ValidationGroup="a">Enter road_access</asp:RequiredFieldValidator>
				Grvl(Gravel) -1,Pave(Paved) - 2
			  
				
			</div>

             <div class="form-group">

            <asp:TextBox class="form-control input-lg" placeholder="Enter alley_access" tabindex="4" ID="txtalley_access" runat="server" Width=50%></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ErrorMessage="Enter alley_access" ControlToValidate="txtalley_access" 
                    CssClass="validation" ToolTip="Enter alley_access" ValidationGroup="a">Enter alley_access</asp:RequiredFieldValidator>
				
			  Grvl(Gravel) -1,Pave(Paved) - 2
				
			</div>
             <div class="form-group">

            <asp:TextBox class="form-control input-lg" placeholder="Enter General_shape" tabindex="4" ID="txtGeneral_shape" runat="server" Width=50%></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ErrorMessage="Enter General_shape" ControlToValidate="txtGeneral_shape" 
                    CssClass="validation" ToolTip="Enter General_shape" ValidationGroup="a">Enter General_shape</asp:RequiredFieldValidator>
				
			  
				 Reg(Regular) -1,IR1(Slightly irregular) -2, IR2(Moderately Irregular) - 3,IR3(Irregular) - 4
			</div>
             <div class="form-group">

            <asp:TextBox class="form-control input-lg" placeholder="Enter Flatness" tabindex="4" ID="txtFlatness" runat="server" Width=50%></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ErrorMessage="Enter Flatness" ControlToValidate="txtFlatness" 
                    CssClass="validation" ToolTip="Enter Flatness" ValidationGroup="a">Enter Flatness</asp:RequiredFieldValidator>
				
			  Bnk(Banked) - Quick and significant rise from street grade to building -1,HLS(Hillside) - Significant slope from side to side - 2 Low- 3, Depression - 4
				
			</div>
             <div class="form-group">

            <asp:TextBox class="form-control input-lg" placeholder="Enter Slope" tabindex="4" ID="txtSlope" runat="server" Width=50%></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ErrorMessage="Enter Slope" ControlToValidate="txtSlope" 
                    CssClass="validation" ToolTip="Enter Slope" ValidationGroup="a">Enter Slope</asp:RequiredFieldValidator>
				Gtl(Gentle slope) - 1,Mod(Moderate Slope) -2, Sev(Severe Slope) - 3
			  
				
			</div>

             
			
			<div class="row">
				<div class="col-xs-12 col-md-6">
                    <asp:Button ID="btnRegister" runat="server" Text="Predict" 
                        class="btn btn-primary btn-block btn-lg" Width=50% 
                        ValidationGroup="a" onclick="btnRegister_Click" />
                    <br />
                    <asp:Label ID="lblPrice" runat="server"></asp:Label>
                </div>

                       
				
			</div>
		
	

</div>

<br />
<br />


</asp:Panel>
</asp:Content>
