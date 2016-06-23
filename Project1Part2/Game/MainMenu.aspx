<%@ Page Title="MainMenu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="Project1Part2.MainMenu" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="row">

            <div class="col-md-offset-3 col-md-6">

                <h1>Main Menu</h1>

                <div class="well">

                    <h3><i class="fa fa-leanpub fa-lg"></i> Games</h3>

                    <div class="list-group">

                        <a class="list-group-item" href="/Game/Games.aspx"><i class="fa fa-th-list"></i> Game List</a>

                        <a class="list-group-item" href="/Game/GameDetails.aspx"><i class="fa fa-plus-circle"></i> Add Game</a>

                    </div>

                </div>
                </div>
            </div>
        </div>
</asp:Content>
