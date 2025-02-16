﻿// Fires when the value of the widget changes
const changeHandler = (e) => console.log("Changed", e);

// Fires when the dropdown is closed
const closedHandler = (e) => console.log(e.component.NAME + " closed");

// Fires when the widget content is fully loaded and ready
const contentReadyHandler = (e) => console.log("Content is ready");

// copy input field
const copyHandler = () => alert("copy create ");

// copy input field
const cutHandler = () => alert("Cut");

// paste 
const pasteHandler = () => alert("Pasted");

// Fires when the widget is being removed
const disposeHandler = (e) => alert("Disposing", e);

// Fires when the Enter key is pressed
const enterKeyHandler = () => alert("enter key pressed");

// Fires when the widget gains focus
const focusInHandler = (e) => console.log("Focused in", e.event.type);

// Fires when the widget loses focus
const focusOutHandler = (e) => console.log("Focused out", e.event.type);

// Fires when the widget is initialized
const initializedHandler = (e) => console.log("Initialized");

// Fires when the user types in the input field
const inputHandler = (e) =>
    console.log("Input received", e.event.currentTarget.value);

// Fires when a key is pressed down inside the widget input
const keyDownHandler = (e) =>
    console.log("Key down", e.event.key, e.event.keyCode);

// Fires when a key is released inside the widget input
const keyUpHandler = (e) => console.log("Key up", e.event.key, e.event.keyCode);

// Fires when a key is pressed and released (deprecated in modern browsers)
const keyPressHandler = (e) =>
    console.log("Key press", e.event.key, e.event.keyCode);

// Fires when the dropdown is opened
const openedHandler = (e) => console.log(e.component.NAME + " opened");

// Fires when a widget option is changed dynamically
const optionChangedHandler = (e) =>
    console.log("Option changed", e.name);

// Fires when the value of the widget is changed (with previous and new value)
const valueChangedHandler = (e) =>
    console.log(`Value changed "${e.value}"`);



export {
    changeHandler,
    closedHandler,
    contentReadyHandler,
    copyHandler,
    cutHandler,
    pasteHandler,
    disposeHandler,
    enterKeyHandler,
    focusInHandler,
    focusOutHandler,
    initializedHandler,
    inputHandler,
    keyDownHandler,
    keyUpHandler,
    keyPressHandler,
    openedHandler,
    optionChangedHandler,
    valueChangedHandler,
};