<form id="playGame" data-bind="submit: playGame">
    <fieldset>       
        <div>
            <h5>Player One</h5>
            <table>
                <tr>
                    <td>
                        <label for="Name">Name</label>
                    </td> 
                    <td>
                        <input type="text" name="Name" style="width:100px" />
                    </td>                   
                </tr>
                <tr>
                    <td>
                        <label for="Strategy">Strategy</label>
                    </td>
                    <td>
                        <input type="text" name="Strategy" style="width:100px" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <h5>Player Two</h5>
            <table>
                <tr>
                    <td>
                        <label for="Name">Name</label>
                    </td>
                    <td>
                        <input type="text" name="Name" style="width:100px" />
                    </td> 
                </tr> 
                <tr>
                    <td>
                        <label for="Strategy">Strategy</label>
                    </td> 
                    <td>
                        <input type="text" name="Strategy" style="width:100px" />
                    </td>
                </tr>
            </table>                      
        </div>
        <input type="submit" value="play" />
    </fieldset>
</form>

@Section Scripts
    @Scripts.Render("~/bundles/knockout")
    <script type="text/javascript">
        function GameViewModel() {
            var self = this;
            self.game = ko.observableArray([]);

            self.playGame = function () {
                $.post("api/game",
                    $("#playGame").serialize(),
                    function (value) {
                        self.contacts.push(value);
                    },
                    "json");
            }
            self.removeContact = function (contact) {
                $.ajax({
                    type: "DELETE",
                    url: contact.Self,
                    success: function () {
                        self.contacts.remove(contact);
                    }
                });
            }

            $.getJSON("api/game", function (data) {
                self.contacts(data);
            });
        }
        ko.applyBindings(new GameViewModel());
    </script>

End Section
