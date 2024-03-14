function searchText() {
    // Obtener el valor del campo de búsqueda
    var searchText = document.getElementById("searchInput").value;

    // Limpiar resaltados anteriores
    var elements = document.getElementsByClassName("highlight");
    for (var i = 0; i < elements.length; i++) {
        elements[i].classList.remove("highlight");
    }

    // Búsqueda en todo el documento
    var textNodes = document.evaluate("//text()", document, null, XPathResult.UNORDERED_NODE_SNAPSHOT_TYPE, null);
    for (var i = 0; i < textNodes.snapshotLength; i++) {
        var node = textNodes.snapshotItem(i);
        if (node.nodeType === Node.TEXT_NODE) {
            if (node.nodeValue.toLowerCase().includes(searchText.toLowerCase())) {
                // Resaltar el nodo
                var span = document.createElement("span");
                span.className = "highlight";
                node.parentNode.insertBefore(span, node);
                span.appendChild(node);
            }
        }
    }
}

