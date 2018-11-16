import React, { Component } from 'react';
import { Button, Modal } from 'react-bootstrap'
import DatePicker from 'react-date-picker';

class InventoryDateAdd extends Component {
    constructor(props, context) {
        super(props, context);
        
        this.handleHide = this.handleHide.bind(this);
        this.addDate = this.addDate.bind(this);

        this.state = {
            show: false,
            date: new Date(),
        };
    }

    handleHide() {
        this.setState({ show: false });
    }

    onChange = date => this.setState({ date })

    addDate() {
        var newDate = {
            "date": this.state.date,
            "dateget2price": this.state.date
        }
        fetch('api/inventoryDate/',
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(newDate)
            });
        this.setState({ show: false });
    }

    render() {
        return (
            <div className="modal-container" style={{ height: 200 }}>
                <Button
                    bsStyle="primary"
                   
                    onClick={() => this.setState({ show: true })}>
                   Add Inventory Date
                </Button>

                <Modal
                    show={this.state.show}
                    onHide={this.handleHide}
                    container={this}
                    aria-labelledby="contained-modal-title"
                >
                    <Modal.Header closeButton>
                          <Modal.Title id="contained-modal-title">
                           Add Inventory Date
                         </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                       Enter Date
                         <DatePicker
                            onChange={this.onChange}
                            value={this.state.date}
                              />
                      </Modal.Body>
                    <Modal.Footer>
                        <Button onClick={this.handleHide}>Close</Button>
                        <Button onClick={this.addDate} >Save changes</Button>
                    </Modal.Footer>
                </Modal>
            </div>
        );
    }
}

export default InventoryDateAdd;