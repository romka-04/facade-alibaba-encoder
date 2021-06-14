window.clipboardCopy = {
    copyText: function (codeElement) {
        navigator.clipboard.writeText(codeElement.textContent).then(function () {
                alert("Copied to clipboard!");
            })
            .catch(function (error) {
                alert(error);
            });
    },
    init: function(elementId) {
        var elem = document.getElementById(elementId);
        if (!elem) {
            throw new Error('No element with ID ' + elementId);
        }

        $(elem).tooltip();
    },
    copy: function (elementId, data) {
        var elem = document.getElementById(elementId);
        if (!elem) {
            throw new Error('No element with ID ' + elementId);
        }
        var $elem = $(elem);


        navigator.clipboard.writeText(data).then(function () {
                $elem
                    .attr('title', 'Copied!')
                    .tooltip('_fixTitle')
                    .tooltip('show');
                setTimeout(function() {
                        $elem
                            .attr('title', 'Copy to clipboard')
                            .tooltip('_fixTitle')
                            .tooltip('show');
                    },
                    1000);
            })
            .catch(function (error) {
                alert(error);
            });
    }
}