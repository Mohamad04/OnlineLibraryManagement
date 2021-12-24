<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookissuing.aspx.cs" Inherits="OnlineLibraryManagement.adminbookissuing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {                        // jQuery to add search button
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">
        <div class="row">

            <div class="col-md-5 ">               <!-- mx class to center -->
                <div class="card">                <!-- class for card -->
                    <div class="card-body">

                        <div class="row">
                            <div class="col text-center">
                                <h4>Book Issuing </h4>
                            </div>
                        </div>
                        <br>

                        <div class="row">
                            <div class="col text-center">
                                <img width="100" src="imgs/books.png" />
                            </div>
                        </div>
                        <br>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1"
                                        runat="server" placeholder="Member ID"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <!-- boostrap class (group of 2 inputs) -->
                                        <asp:TextBox CssClass="form-control" ID="TextBox2"
                                            runat="server" placeholder="Book ID"></asp:TextBox>
                                        <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                        <asp:Button ID="Button1" class="btn btn-primary"
                                            runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <br>



                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3"
                                        runat="server" placeholder="Member Name" ReadOnly="True"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4"
                                        runat="server" placeholder="Book Name" ReadOnly="True"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>
                        </div>
                        <br>



                        <div class="row">
                            <div class="col-md-6">
                                <label>Start Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5"
                                        runat="server" placeholder="Start Date" TextMode="Date"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6"
                                        runat="server" placeholder="End Date" TextMode="Date"></asp:TextBox>
                                    <!-- CssClass for asp component(use DB) and class for html component can work too -->
                                </div>
                            </div>
                        </div>
                        <br>



                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="Button2" class="btn btn-primary btn-block btn-lg"
                                    runat="server" Text="Issue" OnClick="Button2_Click" />
                            </div>

                            <div class="col-6">
                                <asp:Button ID="Button3" class="btn btn-success btn-block btn-lg"
                                    runat="server" Text="Return" OnClick="Button3_Click" />
                            </div>

                        </div>

                        <br>
                    </div>
                </div>
            </div>



            <div class="col-md-7 ">
                <div class="card"> 
                    <div class="card-body">

                        <div class="row">
                            <div class="col text-center">
                                <h4>Issued Book List</h4>
                            </div>
                        </div>
                        <br>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SERHANACER\SQLEXPRESS;Initial Catalog=elibraryDB;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
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
