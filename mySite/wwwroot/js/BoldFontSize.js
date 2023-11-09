$(
    function () {
        const FONTS = ["Times", "Arial", "Georgia", "Verdana", "Monospace", "Courier"];
        let currentFont = 0;
        let fontBold = true;

        $("button").click(function (e) {
            btnClicked = e.target.id;
            switch (btnClicked) {
                case "larger":
                    $("#postContent p").css("font-size", "+=1.5em");
                    break;

                case "smaller":
                    $("#postContent p").css("font-size", "-=0.5em");
                    break;

                case "nextFont":
                    if (currentFont < 5) {
                        currentFont++;
                    } else {
                        currentFont = 0;
                    }

                    $("#postContent p").css("font-family", FONTS[currentFont]);
                    break;

                case "bold":
                    if (fontBold == true) {
                        $("#postContent p").css("font-weight", "bold");
                        fontBold = !fontBold;
                    } else {
                        $("#postContent p").css("font-weight", "normal");
                        fontBold = !fontBold;
                    }
                    break;
            }
        });
    }
)