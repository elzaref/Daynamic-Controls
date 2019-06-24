
//get dynamic part to add and add the value if it is preview page or index in case of return from preview
function GetDynamicTextBox(value) {
    var div = $("<div />").attr("class", "answers");

    //
    var radio = $("<input />").attr("type", "radio").attr("name", "CorrectAnswer").attr("checked", false)
        .attr("onchange", "RadioChange(this)").attr("class", "answerelement");
    radio.val(value);
    div.append(radio);

    var textBox = $("<input />").attr("type", "textbox").attr("name", "AnswersText")
        .attr("onchange", "TextBoxContentChange(this)").attr("class", "answerelement");
    textBox.val(value);
    var testval = textBox.val()
    div.append(textBox);

    var score = $("<input />").attr("type", "number").attr("min", 0).attr("max", 1)
        .attr("name", "score").attr("class", "answerelement").attr('disabled', 'disabled').attr("value",0);
    div.append(score);

    var button = $("<input />").attr("type", "button").attr("value", "Remove").attr("class", "removebutton answerelement");
    button.attr("onclick", "RemoveTextBox(this)");
    div.append(button);

    return div;
}
// to add new dynamic part
function AddTextBox() {
    var div = GetDynamicTextBox("");
    $("#TextBoxContainer").append(div);
    CheckLessThanTwoAnswers();
}
// to remove dynamic part
function RemoveTextBox(button) {

    $(button).parent().remove();
    CheckLessThanTwoAnswers();
}
// to hide remove button if there are just two answers exist
function CheckLessThanTwoAnswers() {
    if ($("#TextBoxContainer > div").length > 2)
        $(".removebutton").show();
    else
        $(".removebutton").hide();
}
//when write in textbox change it bind value to radio and score to keep them updated
function TextBoxContentChange(textbox) {
    var va = $(textbox).val();
    $(textbox).prev().val(va);
    $(textbox).next().val(0);
}
//handle radio button change value
function RadioChange(radio) {

    if ($(radio).is(':checked')) {
        $('input[name=score]').val(0);
        $(radio).next().next().val(1);
    }
}


