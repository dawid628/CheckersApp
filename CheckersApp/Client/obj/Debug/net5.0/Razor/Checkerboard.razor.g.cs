#pragma checksum "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "605ef1fa0941fca64d0ed2da1a1c4dbb7bfaf8fa"
// <auto-generated/>
#pragma warning disable 1591
namespace CheckersApp.Client
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using CheckersApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\_Imports.razor"
using CheckersApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
using Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    public partial class Checkerboard : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 217 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
 for (int i = 0; i < 8; i++)
{
    int localI = i;

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "row");
#nullable restore
#line 221 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
         if (gameOn == true)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 223 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
             for (int j = 0; j < 8; j++)
            {
                int localJ = j;
                var checker = blackCheckers.FirstOrDefault(n => n.Column == j && n.Row == i);
                if (checker == null)
                {
                    checker = whiteCheckers.FirstOrDefault(n => n.Column == j && n.Row == i);
                }

                bool canMoveHere = cellsPossible.Contains((i, j));


#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 234 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
                               () => MoveChecker(localI, localJ)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "class", "cell" + " " + (
#nullable restore
#line 234 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
                                                                                canMoveHere ? "active" : ""

#line default
#line hidden
#nullable disable
            ));
#nullable restore
#line 235 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
                     if (checker != null)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 237 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
                                       () => CheckerClicked(checker)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "class", "checker" + " " + (
#nullable restore
#line 238 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
                                             checker.Color

#line default
#line hidden
#nullable disable
            ) + " " + (
#nullable restore
#line 238 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
                                                             checker == activeChecker ? "active" : ""

#line default
#line hidden
#nullable disable
            ));
            __builder.OpenElement(8, "span");
            __builder.AddContent(9, 
#nullable restore
#line 239 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
                                    checker.Direction == CheckerDirection.Both ? "K" : ""

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 241 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 243 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 243 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
             
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 246 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 247 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
 if (gameOn == false)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(10, "<span style=\"font-size:100px\">Game Over</span>\r\n    <br>\r\n    ");
            __builder.OpenElement(11, "p");
            __builder.AddAttribute(12, "style", "font-size:50px");
            __builder.AddContent(13, 
#nullable restore
#line 251 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
                               winner

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 252 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
    HubConnection.SendAsync("Delete", TableId);
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 3 "C:\Users\User\source\repos\CheckersApp\CheckersApp\Client\Checkerboard.razor"
       
    [Parameter] public HubConnection HubConnection { get; set; }
    [Parameter] public string TableId { get; set; }
    [Parameter] public string playerName { get; set; }
    [Parameter] public bool IsWhitePlayer { get; set; }

    List<Checker> blackCheckers = new List<Checker>();
    List<Checker> whiteCheckers = new List<Checker>();
    string whitePlayer = "x";
    string blackPlayer = "x";

    protected override void OnInitialized()
    {
        if (IsWhitePlayer) { whitePlayer = playerName; }
        if (!IsWhitePlayer) { blackPlayer = playerName; }
        for (int i = 0; i < 3; i++)
        {
            for (int j = (i + 1) % 2; j < 8; j += 2)
            {
                blackCheckers.Add(new Checker
                {
                    Color = "black",
                    Column = j,
                    Row = i,
                    Direction = CheckerDirection.Down
                });
            }
        }

        for (int i = 5; i < 8; i++)
        {
            for (int j = (i + 1) % 2; j < 8; j += 2)
            {
                whiteCheckers.Add(new Checker
                {
                    Color = "white",
                    Column = j,
                    Row = i,
                    Direction = CheckerDirection.Up
                });
            }
        }

        HubConnection.On("TableJoined", () =>
        {
            if (IsWhitePlayer)
            {
                whitePlayer = playerName;
            }
            if (!IsWhitePlayer)
            {
                blackPlayer = playerName;
            }
        });

        HubConnection.On<int, int, int, int>("Move", ServerMove);

        void ServerMove(int previousColumn, int previousRow, int newColumn, int newRow)
        {
            var checker = blackCheckers.FirstOrDefault(n => n.Column == previousColumn && n.Row == previousRow);
            if (checker == null)
            {
                checker = whiteCheckers.FirstOrDefault(n => n.Column == previousColumn && n.Row == previousRow);
            }
            activeChecker = checker;
            EvaluateCheckerSpots();
            MoveChecker(newRow, newColumn);
        }
    }

    Checker activeChecker = null;
    List<(int row, int column)> cellsPossible = new();
    string winner = "";
    int emptyMoves = 0;

    void EvaluateGameStatus()
    {
        if (blackCheckers.Count == 0)
        {
            gameOn = false;
            winner = "white checkers won " + whitePlayer;
        }
        if (whiteCheckers.Count == 0)
        {
            gameOn = false;
            winner = "black checkers won " + blackPlayer;
        }
        if (emptyMoves == 20)
        {
            gameOn = false;
            winner = "draw";
        }
    }

    void EvaluateCheckerSpots()
    {
        cellsPossible.Clear();
        if (activeChecker != null)
        {
            List<int> rowsPossible = new List<int>();
            if (activeChecker.Direction == CheckerDirection.Down ||
                activeChecker.Direction == CheckerDirection.Both)
            {
                rowsPossible.Add(activeChecker.Row + 1);
            }
            if (activeChecker.Direction == CheckerDirection.Up ||
                activeChecker.Direction == CheckerDirection.Both)
            {
                rowsPossible.Add(activeChecker.Row - 1);
            }

            foreach (var row in rowsPossible)
            {
                EvaluateSpot(row, activeChecker.Column - 1);
                EvaluateSpot(row, activeChecker.Column + 1);
            }
        }
    }

    void EvaluateSpot(int row, int column, bool firstTime = true)
    {
        var blackChecker = blackCheckers.FirstOrDefault(
            n => n.Column == column && n.Row == row);

        var whiteChecker = whiteCheckers.FirstOrDefault(
            n => n.Column == column && n.Row == row);

        if (blackChecker == null && whiteChecker == null)
        {
            cellsPossible.Add((row, column));
        }
        else if (firstTime)
        {
            // can i jump this checker?
            if ((whiteTurn && blackChecker != null) ||
                (!whiteTurn && whiteChecker != null))
            {
                int columnDifference = column - activeChecker.Column;
                int rowDifference = row - activeChecker.Row;

                EvaluateSpot(row + rowDifference, column + columnDifference, false);
            }
        }
    }

    void MoveChecker(int row, int column)
    {
        bool canMoveHere = cellsPossible.Contains((row, column));
        if (!canMoveHere) {
            return;
        }
        else
        {
            emptyMoves++;
        }

        if (Math.Abs(activeChecker.Column - column) == 2)
        {
            // we jumped something
            int jumpedColumn = (activeChecker.Column + column) / 2;
            int jumpedRow = (activeChecker.Row + row) / 2;

            var blackChecker = blackCheckers.FirstOrDefault(
                n => n.Row == jumpedRow && n.Column == jumpedColumn);

            if (blackChecker != null)
                blackCheckers.Remove(blackChecker);

            var whiteChecker = whiteCheckers.FirstOrDefault(
                n => n.Row == jumpedRow && n.Column == jumpedColumn);

            if (whiteChecker != null)
                whiteCheckers.Remove(whiteChecker);
            emptyMoves = 0;
        }
        HubConnection.SendAsync("Move", TableId, activeChecker.Column, activeChecker.Row, column, row);

        activeChecker.Column = column;
        activeChecker.Row = row;

        if (activeChecker.Row == 0 && activeChecker.Color == "white")
        {
            activeChecker.Direction = CheckerDirection.Both;
        }
        if (activeChecker.Row == 7 && activeChecker.Color == "black")
        {
            activeChecker.Direction = CheckerDirection.Both;
        }

        activeChecker = null;
        whiteTurn = !whiteTurn;
        EvaluateGameStatus();
        EvaluateCheckerSpots();
        StateHasChanged();
    }

    void CheckerClicked(Checker checker)
    {
        if (whiteTurn != IsWhitePlayer)
        {
            return;
        }
        if (whiteTurn && checker.Color == "black")
            return;
        if (!whiteTurn && checker.Color == "white")
            return;
        activeChecker = checker;
        EvaluateCheckerSpots();
    }

    bool whiteTurn = true;
    bool gameOn = true;

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
