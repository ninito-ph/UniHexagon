using UniHexagon.Interfaces;
using UnityEngine;

namespace UniHexagon
{
    public class HexagonalHexMapDisplay : MonoBehaviour, IHexMapDisplay
    {
        private IHexMap _hexMap;
        private GameObject _hexTemplate;

        private float HexTemplateSize => _hexTemplate.GetComponent<RectTransform>().rect.width / 2;

        public void BindTo(IHexMap map)
        {
            _hexMap = map;
        }

        public void InstantiateLayout(Vector3 originPoint)
        {
            foreach (IHex hex in _hexMap.Hexes)
            {
                Instantiate(_hexTemplate, (Vector3) GetCoordinatesOf(hex) + originPoint, Quaternion.identity);
            }
        }

        private Vector2 GetCoordinatesOf(IHex hex)
        {
            float x = HexTemplateSize *
                      (Mathf.Sqrt(3f) * hex.AxialCoordinates.x + Mathf.Sqrt(3f) / 2f * hex.AxialCoordinates.y);
            float y = HexTemplateSize * (3f / 2f * hex.AxialCoordinates.y);

            return new Vector2(x, y);
        }
    }
}