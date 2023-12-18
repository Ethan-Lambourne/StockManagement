function changeAddItemForm() {
    var choiceIndex = document.getElementById("selectType").selectedIndex;

    switch (document.getElementsByTagName("option")[choiceIndex].value) {
        case "laptop":
            document.getElementById("vramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createGraphicsCard").className = "btn btn-success d-none";

            document.getElementById("screenSizeInput").className = "col-sm-4 m-3";
            document.getElementById("ramInput").className = "col-sm-4 m-3";
            document.getElementById("storageInput").className = "col-sm-4 m-3";
            document.getElementById("createLaptop").className = "btn btn-success";
            break;

        case "graphics card":
            document.getElementById("screenSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("ramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createLaptop").className = "btn btn-success d-none";

            document.getElementById("vramInput").className = "col-sm-4 m-3";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3";
            document.getElementById("createGraphicsCard").className = "btn btn-success";
            break;

        default:
            document.getElementById("screenSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("ramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("vramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createGraphicsCard").className = "btn btn-success d-none";
            document.getElementById("createLaptop").className = "btn btn-success d-none";
            console.log("WARNING: chosen type not recognised.")
    }
}