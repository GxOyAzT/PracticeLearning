﻿export function findCookie(key) {
    const cookieValue = document.cookie
        .split('; ')
        .find(row => row.startsWith(key))
        .split('=')[1]
    return cookieValue
}