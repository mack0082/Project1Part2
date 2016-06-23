<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project1Part2.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h1>Games</h1>
                                <asp:Button runat="server"  ID="PreviousWeekButton"  Text="Previous Week"  OnClick="PreviousWeekButton_Click" />
                                <asp:Button runat="server"  ID="NextWeekButton" Text="Next Week" OnClick="NextWeekButton_Click"  />

            <div class="col-md-offset-2 col-md-8">
                <asp:GridView ID="GameGridView" runat="server" 
                    Class="thumbnail" ShowHeader="true" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False"
                    PagerStyle-CssClass="pagination-ys" PageSize="4" AllowPaging="false">
                   
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                 <div class="4u 12u$(medium)">
                                      <h1><%# Eval("GameDate") %></h1>
                                    <h2><%# Eval("GameName") %></h2>
                                     <h5><%# Eval("Description") %></h5>
                                       <h5><%# Eval("ScoreOfTeamA") %></h5>
                                       <h5><%# Eval("ScoreOfTeamB") %></h5>
                                      <h5><%# Eval("WinningTeam") %></h5>
                                       
                                </div>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                       </Columns>
                      

                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
