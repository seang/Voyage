Thanks to [OrionFive](https://github.com/OrionFive) for putting this original example together, I've forked here for compability updates

# voyage

A simple test demonstrating interacting with the voyage creator studio.

[This](https://voyage-web-main.netlify.app/experience/2cf781c79549/unity%20test%20update/code) is the matching creator studio project.

### Unity Version Differences

@seang: While building on Unity 2022.1.17f1 I found that I had to assign the unityInstance in the script onload in the generated index.html file in order for the rest of the code to work as expected:

```
window.unity = unityInstance
```

```
  script.onload = () => {
        createUnityInstance(canvas, config, (progress) => {
          progressBarFull.style.width = 100 * progress + "%";
        }).then((unityInstance) => {
          window.unity = unityInstance
          loadingBar.style.display = "none";
          fullscreenButton.onclick = () => {
            unityInstance.SetFullscreen(1);
          };
        }).catch((message) => {
          alert(message);
        });
      };
```

More details from users with similar issues here: [https://forum.unity.com/threads/unityinstance-is-not-defined.950269/
](Unity)
