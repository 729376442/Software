using UnityEngine;
using EscapeFromTarkovCheat.Data;
using EscapeFromTarkovCheat.Utils;

namespace EscapeFromTarkovCheat.Feauters.ESP
{
    public static class PlayerBones
    {
        public static void DrawSkeleton(GamePlayer gamePlayer, Color _skeletonColor)
        {
            if (GameUtils.IsPlayerValid(gamePlayer.Player))
            {
                // Déterminez la couleur du squelette en fonction de la visibilité du joueur
                Color skeletonColor = GameUtils.IsPlayerVisible(gamePlayer.Player) ? Color.green : Color.red;

                // Tête et cou
                Vector3 headPos = gamePlayer.GetBonePosition(BoneType.HumanHead);
                Vector3 neckPos = gamePlayer.GetBonePosition(BoneType.HumanNeck);
                Vector3 spinePos = gamePlayer.GetBonePosition(BoneType.HumanSpine3);
                Vector3 pelvisPos = gamePlayer.GetBonePosition(BoneType.HumanPelvis);

                // Épaules et bras
                Vector3 leftShoulderPos = gamePlayer.GetBonePosition(BoneType.HumanLCollarbone);
                Vector3 leftUpperArmPos = gamePlayer.GetBonePosition(BoneType.HumanLUpperarm);
                Vector3 leftElbowPos = gamePlayer.GetBonePosition(BoneType.HumanLForearm1);
                Vector3 leftForearmPos = gamePlayer.GetBonePosition(BoneType.HumanLForearm2);
                Vector3 leftHandPos = gamePlayer.GetBonePosition(BoneType.HumanLPalm);

                Vector3 rightShoulderPos = gamePlayer.GetBonePosition(BoneType.HumanRCollarbone);
                Vector3 rightUpperArmPos = gamePlayer.GetBonePosition(BoneType.HumanRUpperarm);
                Vector3 rightElbowPos = gamePlayer.GetBonePosition(BoneType.HumanRForearm1);
                Vector3 rightForearmPos = gamePlayer.GetBonePosition(BoneType.HumanRForearm2);
                Vector3 rightHandPos = gamePlayer.GetBonePosition(BoneType.HumanRPalm);

                // Hanches et jambes
                Vector3 leftHipPos = gamePlayer.GetBonePosition(BoneType.HumanLThigh1);
                Vector3 leftThigh2Pos = gamePlayer.GetBonePosition(BoneType.HumanLThigh2);
                Vector3 leftKneePos = gamePlayer.GetBonePosition(BoneType.HumanLCalf);
                Vector3 leftCalfPos = gamePlayer.GetBonePosition(BoneType.HumanLCalf);
                Vector3 leftFootPos = gamePlayer.GetBonePosition(BoneType.HumanLFoot);

                Vector3 rightHipPos = gamePlayer.GetBonePosition(BoneType.HumanRThigh1);
                Vector3 rightThigh2Pos = gamePlayer.GetBonePosition(BoneType.HumanRThigh2);
                Vector3 rightKneePos = gamePlayer.GetBonePosition(BoneType.HumanRCalf);
                Vector3 rightCalfPos = gamePlayer.GetBonePosition(BoneType.HumanRCalf);
                Vector3 rightFootPos = gamePlayer.GetBonePosition(BoneType.HumanRFoot);

                // Dessin du squelette
                // Tête et cou
                Render.DrawBoneLine(headPos, neckPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(neckPos, spinePos, 1.5f, skeletonColor);
                Render.DrawBoneLine(spinePos, pelvisPos, 1.5f, skeletonColor);

                // Épaules et bras
                Render.DrawBoneLine(neckPos, leftShoulderPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(leftShoulderPos, leftUpperArmPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(leftUpperArmPos, leftElbowPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(leftElbowPos, leftForearmPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(leftForearmPos, leftHandPos, 1.5f, skeletonColor);

                Render.DrawBoneLine(neckPos, rightShoulderPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(rightShoulderPos, rightUpperArmPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(rightUpperArmPos, rightElbowPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(rightElbowPos, rightForearmPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(rightForearmPos, rightHandPos, 1.5f, skeletonColor);

                // Hanches et jambes
                Render.DrawBoneLine(pelvisPos, leftHipPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(leftHipPos, leftThigh2Pos, 1.5f, skeletonColor);
                Render.DrawBoneLine(leftThigh2Pos, leftKneePos, 1.5f, skeletonColor);
                Render.DrawBoneLine(leftKneePos, leftCalfPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(leftCalfPos, leftFootPos, 1.5f, skeletonColor);

                Render.DrawBoneLine(pelvisPos, rightHipPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(rightHipPos, rightThigh2Pos, 1.5f, skeletonColor);
                Render.DrawBoneLine(rightThigh2Pos, rightKneePos, 1.5f, skeletonColor);
                Render.DrawBoneLine(rightKneePos, rightCalfPos, 1.5f, skeletonColor);
                Render.DrawBoneLine(rightCalfPos, rightFootPos, 1.5f, skeletonColor);
            }
        }
    }
}
