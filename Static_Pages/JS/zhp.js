function ZHPSetup(){
    var copyrightID = "footer-copyright";
    //Getting the current calendar year, and inserting it into the copyright notice at the bottom of the page.
    document.getElementById(copyrightID).innerHTML = "&copy; " + (new Date()).getFullYear() + " " + document.getElementById(copyrightID).innerHTML;
}