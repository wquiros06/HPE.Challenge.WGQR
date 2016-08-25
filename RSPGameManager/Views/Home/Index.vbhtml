<div class="jumbotron">
    <h1>RPS Game</h1>
    <p class="lead">"These general rules apply to all RPS (Rock, Paper, Scissors) games, its tripartite variants known in 
        any permutation and/or combination of the following Scissors Paper Rock/Stone and by any other name that is currently
        known or unknown to the World RPS Society including Roshambo, Jaken, JanKenPo."</p>
    <p><a href="http://worldrps.com/game-basics/the-official-rules-of-rock-paper-scissors/" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>
<div class="row">
    <div class="col-md-4">
        <h2>New Game</h2>
        <ul id="winners" data-bind="foreach: winners">
            <li class="ui-widget-content ui-corner-all">
                <label>Winner: </label><h5 data-bind="text: $data.Name"></h5>
            </li>
        </ul>
        <ul id="games" data-bind="foreach: games">
            <li class="ui-widget-content ui-corner-all">
                <label>Winner: </label><h5 data-bind="text: $data.Player.Name"></h5>
            </li>
        </ul>
        @*<label>Winner: </label><h5 data-bind="text: $data.Winner.Name"></h5>*@
        <form data-bind="submit: playGame">
            <div class="ui-widget-content ui-corner-all">
                <h5>Player One</h5>
                <table>
                    <tr>
                        <td>
                            <label for="namePlayerOne">Name</label>
                        </td>
                        <td>
                            <input data-bind="value: namePlayerOne" style="width:100px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="strategyPlayerOne">Strategy</label>
                        </td>
                        <td>
                            <input data-bind="value: strategyPlayerOne" style="width:100px" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="ui-widget-content ui-corner-all">
                <h5>Player Two</h5>
                <table>
                    <tr>
                        <td>
                            <label for="namePlayerTwo">Name</label>
                        </td>
                        <td>
                            <input data-bind="value: namePlayerTwo" style="width:100px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="strategyPlayerTwo">Strategy</label>
                        </td>
                        <td>
                            <input data-bind="value: strategyPlayerTwo" style="width:100px" />
                        </td>
                    </tr>
                </table>
            </div>
            <button class="btn btn-default" type="submit">play</button>
        </form>
    </div>
    <div class="col-md-4">
        <h2>Tournament</h2>
        <p></p>
    </div>
    <div class="col-md-4">
        <h2>Top Champions</h2>
        <form data-bind="submit: topSearch">
            <input data-bind="value: theTopSearch" placeholder="set top search" />
            <button class="btn btn-default" type="submit">search top</button>
        </form>
        <ul id="players" data-bind="foreach: players">
            <li class="ui-widget-content ui-corner-all">
                <label>Name</label><h5 data-bind="text: $data.Name"></h5>
                <label>Score</label><h5 data-bind="text: $data.Score"></h5>               

                @*<p><a data-bind="attr: { href: Self }, click: $root.removePlayer" class="removePlayer ui-state-default ui-corner-all">Remove</a></p>*@
            </li>
        </ul>
    </div>
</div>

@Section Scripts
    @Scripts.Render("~/bundles/knockout")
    <script type="text/javascript">

        function PlayerViewModel() {
            var self = this;
            self.players = ko.observableArray([]);
            self.winners = ko.observableArray([]);
            self.theTopSearch = ko.observable();

            self.namePlayerOne = ko.observable();
            self.strategyPlayerOne = ko.observable();
            self.namePlayerTwo = ko.observable();
            self.strategyPlayerTwo = ko.observable();


            self.addPlayer = function () {
                $.post("api/players",
                    $("#addPlayer").serialize(),
                    function (value) {
                        self.players.push(value);
                    },
                    "json");
            }
            self.removePlayer = function (player) {
                $.ajax({
                    type: "DELETE",
                    url: player.Self,
                    success: function () {
                        self.players.remove(player);
                    }
                });
            }

            self.topSearch = function (top) {
                var data = ko.toJSON(this);
                var theTop = parseInt(this.theTopSearch._latestValue);
                $.ajax({
                    url: "/api/players",
                    type: "GET",
                    dataType: "text JSON",
                    data: { top: theTop },
                    processData: true,
                    success: function (data) {
                        self.players(data);
                    }
                });
            };

            //self.playGame = function () {
            //    $.post("api/game",
            //        $("#playGame").serialize(),
            //        function (value) {
            //            self.Winner.push(value);
            //        },
            //        "json");
            //}

            self.playGame = function (playerOne, playerTwo) {
                //var data = ko.toJSON(this);
                var thePlayerOne = {
                    Name: this.namePlayerOne._latestValue,
                    Strategy: this.strategyPlayerOne._latestValue
                };
                var thePlayerTwo = {
                    Name: this.namePlayerTwo._latestValue,
                    Strategy: this.strategyPlayerTwo._latestValue
                }
                //var namePlayerOne = this.namePlayerOne._latestValue;
                //var strategyPlayerOne = this.strategyPlayerOne._latestValue;
                //var namePlayerTwo = this.namePlayerTwo._latestValue;
                //var strategyPlayerTwo = this.strategyPlayerTwo._latestValue;

                $.ajax({
                    url: "/api/game",
                    type: "POST",
                    //dataType: "json",
                    //ContentType: "application/json",
                    data: {playerOne: thePlayerOne, playerTwo: thePlayerTwo },
                    //processData: true,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        self.winners(data)
                        //return data;
                    }
                });
            };

            $.getJSON("api/players", function (data) {
                self.players(data);
            });

            //$.getJSON("api/game", function (data) {
            //    self.winners(data);
            //});

            //$.getJSON("api/players?top", function (data) {
            //    self.players(data);
            //});
        }
        ko.applyBindings(new PlayerViewModel());


        //function GameViewModel() {
        //    var self = this;
        //    self.games = ko.observableArray([]);
        //    self.namePlayerOne = ko.observable();
        //    self.strategyPlayerOne = ko.observable();
        //    self.namePlayerTwo = ko.observable();
        //    self.strategyPlayerTwo = ko.observable();

        //    self.playGame = function (namePlayerOne, strategyPlayerOne, namePlayerTwo, strategyPlayerTwo) {
        //        var data = ko.toJSON(this);
        //        var namePlayerOne = this.namePlayerOne._latestValue;
        //        var strategyPlayerOne = this.strategyPlayerOne._latestValue;
        //        var namePlayerTwo = this.namePlayerTwo._latestValue;
        //        var strategyPlayerTwo = this.strategyPlayerTwo._latestValue;

        //        $.ajax({
        //            url: "/api/game",
        //            type: "GET",
        //            dataType: "text JSON",
        //            data: { namePlayerOne: namePlayerOne, strategyPlayerOne: strategyPlayerOne, namePlayerTwo: namePlayerTwo, strategyPlayerTwo: strategyPlayerTwo },
        //            processData: true,
        //            success: function (data) {
        //                //self.game.player.push(new player(data));
        //                return data;
        //            }
        //        });
        //    };

        //    //$.getJSON("api/game", function (data) {
        //    //    self.games(data);
        //    //});
        //}
        //ko.applyBindings(new GameViewModel());
    </script>
End Section
