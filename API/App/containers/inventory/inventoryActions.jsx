import { GET_POSTS_SUCCESS, GET_POSTS_ERROR } from './inventoryConstants.jsx'
import "isomorphic-fetch"

export function getPosts() {
    return (dispatch) => {
        fetch(window.constants.page)
            .then((response) => {
                return response.json();
            }).then((data) => {
                dispatch({ type: GET_POSTS_SUCCESS, payload: data });
            }).catch((ex) => {
                dispatch({ type: GET_POSTS_ERROR, payload: ex });
            });
    }
}