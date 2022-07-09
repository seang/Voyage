mergeInto(LibraryManager.library, {

  // This is needed to allow the frame to receive messages from voyage and pass them on to Unity.
  Initialize: function () {
    if (window.addEventListener) {
    window.addEventListener("message", onMessage, false);        
	} 
	else if (window.attachEvent) {
		window.parentattachEvent("onmessage", onMessage, false);
	}
	
	function onMessage(event) {
		window.unity.SendMessage("Dialog", event.data.func, event.data.message);
	}
  },

  // This is the relay function to send messages to Voyage and probably requires adjusting if you want to call different functions (it calls 'submit' at the moment).
  CallGenerator: function (str) {
    //window.alert(UTF8ToString(str));
	
	window.parent.parent.postMessage({
    'func': 'submit',
    'message': UTF8ToString(str)
}, "https://voyage.latitude.io");
  },

  // The following are example methods from Unity, kept for posterity
  PrintFloatArray: function (array, size) {
    for(var i = 0; i < size; i++)
    console.log(HEAPF32[(array >> 2) + i]);
  },

  AddNumbers: function (x, y) {
    return x + y;
  },

  StringReturnValueFunction: function () {
    var returnStr = "bla";
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },

  BindWebGLTexture: function (texture) {
    GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[texture]);
  },

});