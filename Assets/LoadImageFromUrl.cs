using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoadImageFromUrl : MonoBehaviour {

    public InputField inputField;
    public Image imageComponent;
    public Sprite defaultSprite;

    public void LoadImage() {
        string imageUrl = "https://img.pokemondb.net/sprites/brilliant-diamond-shining-pearl/normal/"+inputField.text.Trim().ToLower()+".png";
        // string imageUrl = "https://pokemonspriteapi.sandy-luis-balbuena.repl.co/Sprites/First_151/25-front-n.gif";
        StartCoroutine(LoadImageCoroutine(imageUrl));
    }

    public void Start()
    {
        StartCoroutine(LoadGif());
    }

    IEnumerator LoadImageCoroutine(string imageUrl) {
        // Create a WWW object to download the image
        WWW www = new WWW(imageUrl);

        // Wait for the download to complete
        yield return www;
        Debug.Log(www);

        if (www.error != null) {
            Debug.LogWarning("Failed to load image: " + www.error);
            imageComponent.sprite = defaultSprite;
            yield break;
        }

        // Set the image texture
        // Texture2D texture = www.texture;
        // Debug.Log(texture);

        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(www.bytes);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        imageComponent.sprite = sprite;
    }

    IEnumerator LoadGif() {
        // WWW www = new WWW("https://pokemonspriteapi.sandy-luis-balbuena.repl.co/Sprites/First_151/25-front-n.gif");
        WWW www = new WWW("https://img.pokemondb.net/sprites/brilliant-diamond-shining-pearl/normal/pikachu.png");
        yield return www;

        // create a new texture from the downloaded gif data
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(www.bytes);

        // set the texture to the Image component
        imageComponent.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}
