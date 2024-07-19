using UnityEngine;
using TMPro;

public class TotalEnergyCalculator : MonoBehaviour
{
    public BendingPotentialCalculator bendingCalculator;
    public StretchingPotentialCalculator stretchingCalculator;
    public TorsionalEnergyCalculator torsionalCalculator;
    public TMP_Text totalEnergyText; // TextMeshPro text element to display the total energy
    public float totalEnergy;

    void Update()
    {
        float bendingPotential = bendingCalculator.CalculateBendingPotential() * 0.001f;
        float stretchingPotential = stretchingCalculator.CalculateStretchingPotential();
        float torsionalEnergy = torsionalCalculator.CalculateTorsionalEnergy(torsionalCalculator.CalculateDihedralAngle());

        totalEnergy = Mathf.Clamp(bendingPotential + stretchingPotential + torsionalEnergy, 0, 1000f);
        totalEnergyText.text = "Total Energy: " + totalEnergy.ToString("F2") + " J";
    }
}