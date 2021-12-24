<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="OnlineLibraryManagement.adminmembermanegment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(
            function () {                     // select this entire document and the website is loaded this function is called
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">
        <div class="row">

            <div class="col-md-5 ">
                <!-- mx class to center -->
                <div class="card">
                    <!-- class for card -->
                    <div class="card-body">

                        <div class="row">
                            <div class="col text-center">
                                <h4>Member Details </h4>
                            </div>
                        </div>
                        <br>

                        <div class="row">
                            <div class="col text-center">
                                <img width="100" src="imgs/generaluser.png" />
                            </div>
                        </div>
                        <br>

                        <div class="row">
                            <div class="col">
                                <hr>
                                <!-- horizental rule -->
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <!-- boostrap class (group of 2 inputs) -->
                                        <asp:TextBox CssClass="form-control" ID="TextBox2"
                                            runat="server" placeholder="Member ID" TextMode="Search"></asp:TextBox>
                                        <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                        <asp:LinkButton ID="LinkButton4" class="btn btn-primary"
                                            runat="server" Text="Go" OnClick="LinkButton4_Click"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1"
                                        runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Account status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <!-- boostrap class (group of 2 inputs) -->
                                        <asp:TextBox CssClass="form-control mr-1" ID="TextBox3"
                                            runat="server" placeholder="Status" ReadOnly="True"></asp:TextBox>
                                        <!-- CssClass for asp component(use DB) and class for html component can work too -->

                                        <asp:LinkButton ID="LinkButton3" class="btn btn-success mr-1"
                                            runat="server" Text="A" OnClick="LinkButton3_Click1"><i class="fas fa-check-circle"></i> </asp:LinkButton>

                                        <asp:LinkButton ID="LinkButton1" class="btn btn-warning mr-1"
                                            runat="server" Text="P" OnClick="LinkButton1_Click1"><i class="far fa-pause-circle"></i> </asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" class="btn btn-danger mr-1"
                                            runat="server" Text="D" OnClick="LinkButton2_Click"><i class="fas fa-times-circle"></i> </asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <br>


                        <div class="row">
                            <div class="col-md-3">
                                <label>Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4"
                                        runat="server" placeholder="DOB" ReadOnly="True"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5"
                                        runat="server" placeholder="Contact No" ReadOnly="True"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6"
                                        runat="server" placeholder="Email ID" ReadOnly="True"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>

                        </div>
                        <br>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7"
                                        runat="server" placeholder="State" ReadOnly="True"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8"
                                        runat="server" placeholder="City" ReadOnly="True"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9"
                                        runat="server" placeholder="Pin Code" ReadOnly="True"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>

                        </div>
                        <br>


                        <div class="row">
                            <div class="col-12">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox10"
                                        runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-9 mx-auto">
                                <asp:Button ID="Button6" class="btn btn-danger btn-block btn-lg"
                                    runat="server" Text="Delete User Permanantly" OnClick="Button6_Click1" />
                            </div>
                        </div>

                    </div>
                </div>
                <a href="homepage.aspx">< Back to Home</a>
                <br>
                <br>
            </div>


            <div class="col-md-7 ">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col text-center">
                                <h4>Member List</h4>
                            </div>
                        </div>
                        <br>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SERHANACER\SQLEXPRESS;Initial Catalog=elibraryDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact No" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>



</asp:Content>
