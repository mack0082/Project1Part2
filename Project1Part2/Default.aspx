﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project1Part2.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h1>Games</h1>

            <div class="col-md-offset-2 col-md-8">
                <asp:GridView ID="GameGridView" runat="server" CssClass="table table-bordered table-striped table-hover"
                    Class="thumbnail" ShowHeader="true" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False"
                    PagerStyle-CssClass="pagination-ys" PageSize="4" AllowPaging="false">
                    <Columns>
                        <asp:BoundField DataField="GameId" HeaderText="Game ID" />
                        <asp:BoundField DataField="GameDate" HeaderText="Game Date" Visible="true" SortExpression="GameDate"
                            DataFormatString="{0:MMM dd, yyyy}" />
                        <asp:BoundField DataField="GameName" HeaderText="Game Name" Visible="true" SortExpression="GameName" />
                        <asp:BoundField DataField="Description" HeaderText="Description" Visible="true" SortExpression="Description" />
                        <asp:BoundField DataField="ScoreOfTeamA" HeaderText="Score Of Team A" Visible="true" SortExpression="ScoreOfTeamA" />

                        <asp:BoundField DataField="ScoreOfTeamB" HeaderText="Score Of Team B" Visible="true" SortExpression="ScoreOfTeamB" />
                        <asp:BoundField DataField="WinningTeam" HeaderText="Winning Team" Visible="true" SortExpression="WinningTeam" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
