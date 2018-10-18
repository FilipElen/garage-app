// import actionTypes from "actionTypes";
import axios from "axios";
import {apiLocation} from "./serverUrl";
import actionTypes from "./actionTypes";

export function fetchProducts() {
    return (dispatch) => {
        dispatch({type: actionTypes.FETCH_PRODUCTS});
        return axios
            .get(apiLocation + "/product")
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_PRODUCTS_SUCCESS,
                    payload: response
                })
            })
            .catch(error => {
                dispatch({
                    type: actionTypes.FETCH_PRODUCTS_FAIL,
                    payload: error
                })
            });
    }
}
export function fetchProductsByCategoryAndFilter(category) {
    return (dispatch) => {
        dispatch({type: actionTypes.FETCH_PRODUCTS});
        return axios
            .get(apiLocation + "/product/category/" + category)
            .then(response => {
                dispatch({
                    type: actionTypes.FETCH_PRODUCTS_SUCCESS,
                    payload: response
                });
                dispatch({
                    type: actionTypes.FILTER_STOCK
                });
            })
            .catch(error => {
                dispatch({
                    type: actionTypes.FETCH_PRODUCTS_FAIL,
                    payload: error
                })
            })
    }
}

export function addProduct(productWithCategoryTypes, token) {
    return (dispatch) => {
        dispatch({type: actionTypes.ADD_PRODUCT_START});
        return axios
            .post(
                apiLocation + "/product",
                productWithCategoryTypes,
                {
                    headers: { Authorization: "Bearer " + token }
                }
            ).then(response =>{
                dispatch({
                    type: actionTypes.ADD_PRODUCT_SUCCESS,
                    payload: response
                });
            }).catch(error =>{
                dispatch({
                    type: actionTypes.ADD_PRODUCT_FAIL,
                    payload: error
                })
            });
    }
}

export function handleClickOpenDialog(){
    return (dispatch) =>{
        dispatch({type: actionTypes.DIALOG_OPEN});
    }
}

export function handleClose(){
    return (dispatch) =>{
        dispatch({type: actionTypes.DIALOG_CLOSE})
    }
}
export function filterStock() {
    return (dispatch) => {
        dispatch({type: actionTypes.FILTER_STOCK});
    }
}