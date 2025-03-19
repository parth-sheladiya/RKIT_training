export function createCustomStore({ key, loadUrl, insertUrl, updateUrl, deleteUrl, getByIdUrl }) {
    const token = localStorage.getItem("Token");

    const sendRequest = (url, method, data) => {
        return $.ajax({
            url,
            method,
            headers: { "Authorization": `Bearer ${token}` },
            contentType: "application/json",
            data: data ? JSON.stringify(data) : undefined
        });
    };

    return new DevExpress.data.CustomStore({
        key: key,

        load: function () {
            return sendRequest(loadUrl, "GET").then(res => res.data);
        },

        insert: function (values) {
            return sendRequest(insertUrl, "POST", values).then(res => res.data);
        },

        update: function (key, values) {
            if (getByIdUrl) {
                return sendRequest(`${getByIdUrl}?id=${key}`, "GET").then(res => {
                    return sendRequest(updateUrl, "PUT", { ...res.data, ...values }).then(res => res.data);
                });
            } else {
                return sendRequest(updateUrl, "PUT", { key, ...values }).then(res => res.data);
            }
        },

        remove: function (key) {
            return sendRequest(`${deleteUrl}?id=${key}`, "DELETE").then(res => res.data);
        }
    });
}
