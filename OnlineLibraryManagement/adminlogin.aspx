<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="OnlineLibraryManagement.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
	<div class="row">
		<div class="col-md-6 mx-auto">          <!-- mx class to center -->
			
			<div class="card">                  <!-- class for card -->
				<div class="card-body">           
					
					<div class="row">
						<div class="col text-center">							
					            <img width="150" src="imgs/adminuser.png"/>
						</div>
					</div>

					<div class="row">
						<div class="col text-center">
					           <h3>Admin Login</h3>		
						</div>	
					</div>
					
					<div class="row">
						<div class="col">
							<hr>	        <!-- horizental rule -->
						</div>	
					</div>

					<div class="row">
						<div class="col">
							<label>Admin ID</label>
							<div class="form-group">
                                <asp:TextBox cssClass="form-control" ID="TextBox1" 
									runat="server" placeholder="Admin ID"></asp:TextBox>
						    </div>	

							<label>Password </label>
							<div class="form-group">
                                <asp:TextBox cssClass="form-control" ID="TextBox2" 
									runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
						    </div>

							<div class="form-group">
                                <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />       <!-- classes for styling (lg for big size) -->
						    </div>

						</div>	
					</div>
				</div>
			</div>

			<br>
			
		</div>
	</div>
</div>


</asp:Content>
