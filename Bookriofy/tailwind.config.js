module.exports = {
  content: ["./Pages/**/*.{razor,html}", "./Shared/**/*.{razor,html}"],
  theme: {
    extend: {
      colors: {
        'bright': '#F7F9FB',
        'primary-1': '#31708E',
        'primary-2': '#5085A5',
        'primary-3': '#8FC1E3',
        'accent-dark': '#687864',
      },
      backgroundImage: {
        'hero-1': "url('bailey-zindel-NRQV-hBF10M-unsplash.jpg')"
      },
      screens: {
        '3xl': '1650px',
        '4xl': '1800px'
      }
    },
  },
  plugins: [],
}
