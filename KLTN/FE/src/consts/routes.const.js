const API = {
    LOGIN: '/login',
    DOMAINREGISTER: '/domain/register',
    FORGOT: '/forgot-password',   
    DOMAIN: '/domain',

}
Object.keys(API).map((prop) => 
    API[prop] = `/api/${API[prop]}`
)