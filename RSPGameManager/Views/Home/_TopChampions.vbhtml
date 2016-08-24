@ModelType IList(Of Models.Player)

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

<ul id="players" data-bind="foreach: players">
    <li class="ui-widget-content ui-corner-all">
        <h5 data-bind="text: $data.Name" class="ui-widget-header" style="width:20px"></h5>
        <h5 data-bind="text: $data.Strategy" class="ui-widget-header"></h5>
        <h5 data-bind="text: $data.Score" class="ui-widget-header"></h5>
    </li>
</ul>
    @*<form id="addPlayer" data-bind="submit: addPlayer">
        <fieldset>
            <legend>Add New Player</legend>
            <ol>
                <li>
                    <label for="Name">Name</label>
                    <input type="text" name="Name" />
                </li>
                <li>
                    <label for="Strategy">Strategy</label>
                    <input type="text" name="Strategy">
                </li>
                <li>
                    <label for="City">City</label>
                    <input type="text" name="City" />
                </li>
                <li>
                    <label for="Score">Score</label>
                    <input type="text" name="Score" />
                </li>
            </ol>
            <input type="submit" value="Add" />
        </fieldset>
    </form>*@
