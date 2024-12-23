import React from "react";

const FormContact = (props) => {
    return(
        <div>
            <div className="mb-3">
                <form>
                    <div className="mb-3">
                        <label className="form-label">Введите имя:</label>
                        <textarea className="form-control" rows={1} placeholder="Например qwerty"/>
                    </div>
                    <div className="mb-3">
                        <label className="form-label">Введите Email:</label>
                        <input className="form-control" type="text" placeholder="Например qwerty@mail.ru"/>
                    </div>
                </form>
            </div>

            <div>
                <button
                    className="btn btn-primary"
                    onClick={() => {props.addContact()}}>
                    Добавить контакт
                </button>
          </div>
        </div>
    )
}

export default FormContact;