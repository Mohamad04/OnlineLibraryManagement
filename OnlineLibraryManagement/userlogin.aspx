<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="OnlineLibraryManagement.userlogin" %>
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
					            <img width="150" src="imgs/generaluser.png"/>
						</div>
					</div>


					<div class="row">
						<div class="col text-center">                        
					           <h3>Member Login</h3>	
						</div>	
					</div>
					
					<div class="row">
						<div class="col">
							<hr>	        <!-- horizental rule -->
						</div>	
					</div>

					<div class="row">
						<div class="col">
							<label>Member ID</label>
							<div class="form-group">
                                <asp:TextBox cssClass="form-control" ID="TextBox1" 
									runat="server" placeholder="Member ID" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
						    </div>	

							<label>Password </label>
							<div class="form-group">
                                <asp:TextBox cssClass="form-control" ID="TextBox2" 
									runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
						    </div>

							<div class="form-group">
                                <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />       <!-- classes for styling (lg for big size) -->
						    </div>

							<div class="form-group">
                               <a href="usersignup.aspx"> <input id="Button2" class="btn btn-info btn-block btn-lg" 
									type="button" value="Sign Up" /></a>
						    </div>

						</div>	
					</div>
				</div>
			</div>


			<a href="homepage.aspx"> < Back to Home</a>  <br><br>   <!-- break -->
		</div>
	</div>
</div>



</asp:Content>
