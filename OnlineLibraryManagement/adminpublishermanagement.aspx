<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="OnlineLibraryManagement.adminpublishermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(
            function () {                     // select this entire document and the website is loaded this function is called
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div class="container">
        <div class="row">
            <div class="col-md-5 ">        <!-- mx class to center -->

                <div class="card">         <!-- class for card -->
                    <div class="card-body">

                        <div class="row">
                            <div class="col text-center">
                                <h4>Publisher Details </h4>
                            </div>
                        </div>
                        <br>

                        <div class="row">
                            <div class="col text-center">
                                <img width="100" src="imgs/publisher.png" />
                            </div>
                        </div>
                        <br>

                        <div class="row">
                            <div class="col-md-4">
                                <label> ID</label>
                                <div class="form-group">
                                    <div class="input-group">           <!-- boostrap class (group of 2 inputs) -->
                                        <asp:TextBox CssClass="form-control" ID="TextBox1"
                                            runat="server" placeholder="ID" TextMode="Search" Font-Size="Medium"></asp:TextBox>
                                        <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                        <asp:Button ID="Button1" class="btn btn-primary"
                                            runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2"
                                        runat="server" placeholder="Publisher Name"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <br>


                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-success btn-block btn-lg"
                                    runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>

                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-primary btn-block btn-lg"
                                    runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>

                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-danger btn-block btn-lg"
                                    runat="server" Text="Delete" OnClick="Button4_Click" />
                            </div>
                        </div>

                        <br>
                        <br>
                    </div>
                </div>

                <a href="homepage.aspx">< Back to Home</a>
                <br>
                <br>
                <!-- break -->
            </div>



            <div class="col-md-7 ">
                <div class="card">

                    <div class="card-body">


                        <div class="row">
                            <div class="col text-center">
                                <h4>Publisher List</h4>
                            </div>
                        </div>
                        <br>

                          <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SERHANACER\SQLEXPRESS;Initial Catalog=elibraryDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
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
