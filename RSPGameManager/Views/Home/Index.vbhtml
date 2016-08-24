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
        @Html.Partial("_PlayGame")
    </div>
    <div class="col-md-4">
        <h2>Tournament</h2>
        <p></p>
        <p><a class="btn btn-default" href="">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Top Champions</h2>
        <ul id="players" data-bind="foreach: players">
            <li class="ui-widget-content ui-corner-all">
                <h5 data-bind="text: $data.Name" class="ui-widget-header" style="width:20px"></h5>
                <h5 data-bind="text: $data.Strategy" class="ui-widget-header"></h5>
                <h5 data-bind="text: $data.Score" class="ui-widget-header"></h5>
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

            $.getJSON("api/players", function (data) {
                self.players(data);
            });
        }
        ko.applyBindings(new PlayerViewModel());
    </script>
End Section
