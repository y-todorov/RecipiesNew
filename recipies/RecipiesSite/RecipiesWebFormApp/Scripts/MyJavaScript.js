// this is for the rad menu so root item cannot be clicked.
function OnClientItemClicking(sender, args) {
    if (args.get_item().get_items().get_count() != 0 && args.get_item().get_level() == 0) {
        args.set_cancel(true); // Cancel the event 
    }
}


function OnRequestStart() {
    isInRequest = true;
}

function OnResponseEnd() {
    isInRequest = false;
}