@modelType List(Of Models.Player)
                                   

<ul id="games" data-bind="foreach: games">
    <li class="ui-widget-content ui-corner-all">
        <label>Winner: </label><h5 data-bind="text: $data.Player.Name"></h5>
    </li>
</ul>
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

@Section Scripts
    @Scripts.Render("~/bundles/knockout")
    <script type="text/javascript">
        function GameViewModel() {
            var self = this;
            self.games = ko.observableArray([]);
            self.namePlayerOne = ko.observable();
            self.strategyPlayerOne = ko.observable();
            self.namePlayerTwo = ko.observable();
            self.strategyPlayerTwo = ko.observable();

            self.playGame = function (namePlayerOne, strategyPlayerOne, namePlayerTwo, strategyPlayerTwo) {
                var data = ko.toJSON(this);
                var namePlayerOne = this.namePlayerOne._latestValue;
                var strategyPlayerOne = this.strategyPlayerOne._latestValue;
                var namePlayerTwo = this.namePlayerTwo._latestValue;
                var strategyPlayerTwo = this.strategyPlayerTwo._latestValue;

                $.ajax({
                    url: "/api/game",
                    type: "GET",
                    dataType: "text JSON",
                    data: { namePlayerOne: namePlayerOne, strategyPlayerOne: strategyPlayerOne, namePlayerTwo: namePlayerTwo, strategyPlayerTwo: strategyPlayerTwo },
                    processData: true,
                    success: function (data) {
                        //self.game.player.push(new player(data));
                        return data;
                    }
                });
            };

            $.getJSON("api/game", function (data) {
                self.games(data);
            });
        }
        ko.applyBindings(new GameViewModel());
    </script>

End Section
