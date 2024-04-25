using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class MoveText : MonoBehaviour
{
    public TMP_Text textComponent;

    void Update()
    {
        textComponent.ForceMeshUpdate();
        TMP_TextInfo lettersInfo = textComponent.textInfo;

        for (int i = 0; i < lettersInfo.characterCount; i++)
        {
            TMP_CharacterInfo charInfo = lettersInfo.characterInfo[i];

            if (charInfo.isVisible)
            {
               Vector3[] vertices = lettersInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                for (int j = 0; j < 4; j++) //esto es como una copia de los vertices ahora tenemos que hacer que sea la activa
                {
                    Vector3 origin = vertices[charInfo.vertexIndex + j];
                    vertices[charInfo.vertexIndex + j]= origin+new Vector3(0,Mathf.Sin(Time.unscaledTime * 2f+origin.x*0.01f)*10f,0); //time unscaled tiem porque si no si pauso el menu no se mueven las letras
                }
            }
        }

        for (int i = 0; i < lettersInfo.meshInfo.Length; i++) //la activa
        {
            TMP_MeshInfo meshInfo = lettersInfo.meshInfo[i];
            meshInfo.mesh.vertices=meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh,i);
        }
    }
}
