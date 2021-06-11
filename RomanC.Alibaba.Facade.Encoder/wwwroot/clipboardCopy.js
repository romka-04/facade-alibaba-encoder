window.clipboardCopy = {
    copyText: function (codeElement) {
        navigator.clipboard.writeText(codeElement.textContent).then(function () {
                alert("Copied to clipboard!");
            })
            .catch(function (error) {
                alert(error);
            });
    },
    copy: function (data) {
        navigator.clipboard.writeText(data).then(function () {
                alert("Copied to clipboard!");
            })
            .catch(function (error) {
                alert(error);
            });
    }
}