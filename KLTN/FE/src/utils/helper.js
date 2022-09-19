export function getObjectFromUrl(url) {
    let result = null;
    if (url?.length) {
        result = {};
        let query = url.substr(1);
        query.split("&").forEach(function(part) {
            let item = part.split("=");
            result[item[0]] = decodeURIComponent(item[1]);
        });
    }
    return result;
}