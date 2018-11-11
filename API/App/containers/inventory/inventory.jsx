import React from 'react';
import ReactDOM from 'react-dom';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import queryString from 'query-string';
import { Link } from 'react-router-dom';

import { getPosts } from './inventoryActions.jsx'
import "isomorphic-fetch";class Inventory extends React.Component {    constructor(props) {
        super(props);
        this.state = { query: location.search };
    }    componentDidMount() {
        this.getPosts();
    }    getPosts() {
        this.props.getPosts();
    }    componentWillReceiveProps() {
      
            this.getPosts();
        
    }    
    render() {

        let posts = this.props.posts.records.map(item => {
            return (
                <button key={item.value} />
            );
        });

        return (
            <div id="blog">
                <div id="lenta">
                    {posts}
                </div>
              
            </div>
        );
    }
};

let mapProps = (state) => {
    return {
        posts: state.Inventory.data,
    }
}

let mapDispatch = (dispatch) => {
    return {
        getPosts: bindActionCreators(getPosts, dispatch)
    }
}

export default connect(mapProps, mapDispatch)(Inventory) 