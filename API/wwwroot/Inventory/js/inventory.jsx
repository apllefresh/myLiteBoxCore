import React from 'react';
import Dropdown from 'react-dropdown'
import 'react-table/react-table.css'


class Hello extends React.Component {
    constructor(props) {
        super(props);

        this.state = { options: [] };

    }
    render() {
        return
        <div>
            <h1>Привет, React.JS</h1>
            <Dropdown options={this.state.options} onChange={this.handleChange} placeholder="Select an option" />
            </div>;
    }
}

ReactDOM.render(
    <Hello />,
    document.getElementById("content")
);